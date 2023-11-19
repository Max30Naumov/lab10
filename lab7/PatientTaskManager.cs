using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class PatientTaskManager
    {
        // обюъект блокировки для синхронизации доступа к критическим секциям кода
        private readonly object queueLock = new object();

        // concurrentQueue - потокобезопасная очередь - обеспечение безопасности доступа к очереди из разных потоков
        private ConcurrentQueue<Patient> patientsQueue = new ConcurrentQueue<Patient>();

        // генератор случайных чисел- обладают высоким уровнем случайности и являются непредсказуемыми
        private RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        // мтод для генерации случайной строки указанной длины
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            // генерация масива случайных байтов
            byte[] data = new byte[length];
            rng.GetBytes(data);
            StringBuilder result = new StringBuilder(length);
            // перевод каждого байта в символ и добавлние к результату
            foreach (byte b in data)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString(); 
        }

        //   заполнение очереди случайными объектами
        private void FillQueueWithPatients(int startId, int endId)
        {
            for (int i = startId; i <= endId; i++)
            {
                string firstName = GenerateRandomString(8);
                string lastName = GenerateRandomString(8);
                int age = GenerateRandomAge();

                // сздание нового Patient 
                Patient patient = new Patient(firstName, lastName, age, i);
                patientsQueue.Enqueue(patient);
            }
        }

        //  для генерации случайного возраста 
        private int GenerateRandomAge()
        {
            // генерация массива из 4 случайных байтов
            byte[] data = new byte[4];
            rng.GetBytes(data);

            // перервлд байтов в целое число и обеспечение положительности числа
            int randomNumber = BitConverter.ToInt32(data, 0) & 0x7FFFFFFF;
            return randomNumber % 100 + 1; // 1 - 100
        }

        // vетод для генерации очереди c помощбю количества пациентов для каждого потока
        public ConcurrentQueue<Patient> GeneratePatientsInQueue(List<int> patientsPerThread)
        {
            // массив задач для параллельного выполнения
            Task[] tasks = new Task[patientsPerThread.Count];

            //общнн количество пациентов для генерации
            int totalPatients = patientsPerThread.Sum();

            int startIndex = 1;
            int endIndex = 0;

            // проход по списку количества пациентов для каждого потока
            for (int i = 0; i < patientsPerThread.Count; i++)
            {
                endIndex += patientsPerThread[i]; // аычисление конечного индекса для каждого потока

                int startId = startIndex;
                int endId = endIndex;

                // запуск новой задачи 
                tasks[i] = Task.Run(() =>
                {
                    // заполнение patientsQueue 
                    FillQueueWithPatients(startId, endId);
                    string message = $"Поток {Task.CurrentId} обработал пациентов с {startId} по {endId}";
                    MessageBox.Show(message);
                });

                startIndex = endIndex + 1; // обновление начального индекса
            }
            Task.WaitAll(tasks); // оожидание завершения всех задач
            return patientsQueue;
        }

        public async Task SerializeToJson(string filePath)
        {
            // обеспечение потокобезопасного доступа с помощью объекта блокировки 
            lock (queueLock)
            {
                if (patientsQueue.Count == 0)
                {
                    MessageBox.Show("Очередь пациентов пуста. Данные не будут сохранены.", "Пустая очередь", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string json = string.Empty;
           // асинхронное выполнение сериализации
            await Task.Run(() =>
            {
                lock (queueLock)
                {
                    json = JsonConvert.SerializeObject(patientsQueue);
                }
            });

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    // запись JSON-строки в файл
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        await writer.WriteAsync(json); // асинхронная запись в файл
                    }

                    if (File.Exists(filePath))
                        MessageBox.Show("Данные успешно сохранены в JSON-файл.", "Успешное сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Файл не существует.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка сериализации в JSON.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ConcurrentQueue<Patient> SortParallel(int threadCount)
        {
            if (!patientsQueue.IsEmpty && threadCount > 0)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                // Копирование элементов очереди в список 
                List<Patient> patientsList = patientsQueue.ToList();
                // вычисление размера каждого подмасива для парагллельной обработки
                int chunkSize = (int)Math.Ceiling((double)patientsList.Count / threadCount);
                // разделение списка на подмасивы
                List<List<Patient>> partitions = new List<List<Patient>>();
                for (int i = 0; i < patientsList.Count; i += chunkSize)
                {
                    partitions.Add(patientsList.GetRange(i, Math.Min(chunkSize, patientsList.Count - i)));
                }

                // параллельная сортировка каждого подмасива по имени пациента
                Parallel.ForEach(partitions, partition =>
                {
                    partition.Sort((p1, p2) => string.Compare(p1.FirstName, p2.FirstName, StringComparison.OrdinalIgnoreCase));
                });

                // объединение отсортированных подмасивово обратно в список
                patientsList = partitions.SelectMany(x => x).ToList();
                stopwatch.Stop();
                TimeSpan elapsedTime = stopwatch.Elapsed;         
                patientsQueue = new ConcurrentQueue<Patient>(patientsList);
                MessageBox.Show($"Количество потоков: {threadCount}, Время сортировки: {elapsedTime.TotalMilliseconds} мс", "Замер времени", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return patientsQueue; 
            }
            else
            {
                throw new Exception("Очередь пуста либо количество потоков меньше 1");
            }
        }

        public ConcurrentQueue<Patient> SortNoParallel()
        {
            if (!patientsQueue.IsEmpty)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                List<Patient> patientsList = patientsQueue.ToList();
                // сортировка списка по имени без параллелизма
                patientsList.Sort((p1, p2) => string.Compare(p1.FirstName, p2.FirstName, StringComparison.OrdinalIgnoreCase));
                stopwatch.Stop();
                TimeSpan elapsedTime = stopwatch.Elapsed;
                patientsQueue = new ConcurrentQueue<Patient>(patientsList);

                MessageBox.Show($"Время сортировки без распараллеливания: {elapsedTime.TotalMilliseconds} мс", "Замер времени", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return patientsQueue; 
            }
            else
            {
                throw new Exception("Очередь пуста");
            }
        }

    }
}
