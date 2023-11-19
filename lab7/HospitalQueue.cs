using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab7
{
    public class HospitalQueue
    {
        private Queue<Patient> patientsQueue = new Queue<Patient>();
        public delegate int PatientComparisonDelegate(Patient p1, Patient p2);
        public delegate bool PatientFilteredDelegate(Patient p, string searshValue);

        public HospitalQueue() { }

        //список для отслеживания уникальных ID пациентов
        private List<int> uniqueIds = new List<int>();
        private bool _showMessageOnAdd = true;

        public void SetShowMessageOnAdd(bool show)
        {
            _showMessageOnAdd = show;
        }
        //метод для добавления пациента в очередь
        public void AddPatient(Patient patient)
        {
            //проверка, что ID пациента уникален и больше нуля
            if (IsIdUnique(patient.Id) && patient.Id > 0)
            {
                patientsQueue.Enqueue(patient); //добавляем пациента в очередь
                uniqueIds.Add(patient.Id); //добавляем ID пациента в список уникальных ID
                if (_showMessageOnAdd)
                    MessageBox.Show($"{patient.FirstName} {patient.LastName} добавлен в очередь.", "Добавление пациента", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка. Проверьте ID пациента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //мтод для проверки уникальности ID пациента
        private bool IsIdUnique(int id)
        {
            return !uniqueIds.Contains(id);
        }

        //метод для удаления пациента из очереди по ID
        public void RemovePatientById(int id)
        {
            Patient patientToRemove = null;

            foreach (var patient in patientsQueue)
            {
                if (patient.Id == id)
                {
                    patientToRemove = patient; //находим пациента для удаления
                    break;
                }
            }

            if (patientToRemove != null)
            {
                patientsQueue = new Queue<Patient>(patientsQueue.Except(new[] { patientToRemove })); // удаляем пациента из очереди
                uniqueIds.Remove(id); // Remove the ID from the list of unique IDs
                MessageBox.Show($"{patientToRemove.FirstName} {patientToRemove.LastName} удален из очереди.", "Удаление пациента", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пациент с указанным ID не найден в очереди.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //vетод для отображения текущей очереди пациентов
        public string DisplayQueue()
        {
            // создаем объект StringBuilder для построения строки
            StringBuilder result = new StringBuilder();
            result.AppendLine("Текущая очередь пациентов:");
            //прроходим по каждому пациенту в очереди
            foreach (var patient in patientsQueue)
            {
                result.AppendLine($"Имя: {patient.FirstName} {patient.LastName}, Возраст: {patient.Age}, ID: {patient.Id}");
            }
            // переводимм объект StringBuilder в строку
            return result.ToString();
        }
        // метод для сериализации данных в JSON
        public void SerializeToJson(string filePath)
        {
            // проверка, что очередь не пуста перед сериализацыей
            if (patientsQueue.Count > 0)
            {
                // конвертируем очередь пациентов в JSON строку
                string json = JsonConvert.SerializeObject(patientsQueue);
               // открытие файла для записи
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // запись JSON строки в файл
                    writer.Write(json);
                }
                // проверка был ли создан файл
                if (File.Exists(filePath))
                    MessageBox.Show("Данные успешно сохранены в JSON-файл.", "Успешное сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Файл не существует.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Очередь пациентов пуста. Данные не будут сохранены.", "Пустая очередь", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // метод для десериализации данных из JSON
        public static HospitalQueue DeserializeFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                // читание содержимого JSON
                string json = File.ReadAllText(filePath);

                // проверка, не пустая ли JSON строка
                if (!string.IsNullOrEmpty(json))
                {
                    // десериализуем JSON строку в список 
                    var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                    // создание нового объекта HospitalQueue и добавление пациентов
                    HospitalQueue hospitalQueue = new HospitalQueue();
                    // отключаем уведомления о добавлении пациентов, так как файл может быть большим
                    hospitalQueue.SetShowMessageOnAdd(false);
                    foreach (var patient in patients)
                    {
                        hospitalQueue.AddPatient(patient);
                    }
                    // проверка и обновление списка  ID
                    hospitalQueue.uniqueIds.Clear();

                    foreach (var patient in hospitalQueue.patientsQueue)
                    {
                        hospitalQueue.uniqueIds.Add(patient.Id);
                    }
                    return hospitalQueue;
                }
                else
                {
                    throw new InvalidOperationException("Файл пустой.");
                }

            }
            else
            {
                throw new FileNotFoundException("Файл не найден.");
            }


        }

        // метод для сериализации данных в бинарный файл
        public void SerializeToBinary(string filePath)
        {
            if (patientsQueue.Count > 0)
            {
                // открываем файл для записи в бинарном формате
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // создние объект BinaryFormatter для сериализации и сохранение очереди 
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, patientsQueue);
                }
                //проверка был ли создан файл
                if (File.Exists(filePath))
                    MessageBox.Show("Данные успешно сохранены в BIN-файл.", "Успешное сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Файл не существует.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Очередь пациентов пуста. Данные не будут сохранены.", "Пустая очередь", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // метод для десериализации данных из бинарного файла
        public static HospitalQueue DeserializeFromBinary(string filePath)
        {
            // проверка существуетт ли файл 
            if (File.Exists(filePath))
            {
                // проверка пуст ли файл
                if (new FileInfo(filePath).Length > 0)
                {
                    // открываем файл для чтения
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        //  объект BinaryFormatter для десериализации
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        // десериализация очереди пациентов из файла
                        Queue<Patient> patients = (Queue<Patient>)binaryFormatter.Deserialize(fileStream);
                        HospitalQueue hospitalQueue = new HospitalQueue();
                        //восстанавление очереди пациентов
                        hospitalQueue.patientsQueue = patients;

                        // проверка и обновление списка ID
                        hospitalQueue.uniqueIds.Clear();
                        foreach (var patient in hospitalQueue.patientsQueue)
                        {
                            hospitalQueue.uniqueIds.Add(patient.Id);
                        }
                        return hospitalQueue;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Файл пустой.");
                }
            }
            else
            {
                throw new FileNotFoundException("Файл не найден.");
            }
        }
        public void SortPatients(PatientComparisonDelegate comparisonDelegate)
        {
            // проверка, есть ли пациенты в очереди
            if (patientsQueue.Count > 0)
            {
                // копия списка пациентов для сортировки
                List<Patient> sortedList = patientsQueue.ToList();

                // сортировка компаратором с использованием делегата 
                sortedList.Sort((p1, p2) => comparisonDelegate(p1, p2));

                // присвоение исходному списку нового значения
                patientsQueue = new Queue<Patient>(sortedList);
            }
            else
            {
                MessageBox.Show("Очередь пациентов пуста. Данные не будут отсортированы.", "Пустая очередь", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public HospitalQueue FilterPatients(PatientFilteredDelegate filterDelegate, string searchValue)
        {
            // для хранения отфильтрованных пациентов
            var filteredQueue = new HospitalQueue();

            // провекра, есть ли пациенты в очереди
            if (patientsQueue.Count == 0)
            {
                MessageBox.Show("Очередь пациентов пуста. Нечего фильтровать.", "Пустая очередь", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return filteredQueue;
            }

            // прроход по всем пациентам в началной очереди
            foreach (var patient in patientsQueue)
            {
                // отключаем вывод сообщений при добавлении
                filteredQueue.SetShowMessageOnAdd(false);

                // проверяем, подходит ли пациент по критериям 
                if (filterDelegate(patient, searchValue))
                {
                    // добавляем пациента
                    filteredQueue.AddPatient(patient);
                }
            }

            // провекрка, найдены ли пациенты
            if (filteredQueue.patientsQueue.Count == 0)
            {
                MessageBox.Show("Ни одного пациента не найдено по заданным критериям.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return filteredQueue;
        }


    }
}

