namespace lab7
{
    public partial class Form1 : Form
    {
        private HospitalQueue hospitalQueue;
        private lab10 newForm;

        public Form1()
        {
            InitializeComponent();
            hospitalQueue = new HospitalQueue();
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            UpdateQueueListBox();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string firstName = TBFirstName.Text;
            string lastName = TBLastName.Text;

            //проверка на правильный тип даных
            if (int.TryParse(TBAge.Text, out int age) && int.TryParse(TBId.Text, out int id))
            {
                Patient patient = new Patient(firstName, lastName, age, id);
                hospitalQueue.AddPatient(patient);
                UpdateQueueListBox(); //обновляем список очереди
            }
            else
            {
                MessageBox.Show("Неправильный формат введенных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // очстка текстовых полей
            TBFirstName.Clear();
            TBLastName.Clear();
            TBAge.Clear();
            TBId.Clear();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            int.TryParse(TBId.Text, out int id);
            hospitalQueue.RemovePatientById(id); // удаляем пациента из очереди по ID
            UpdateQueueListBox();
            TBId.Clear();
        }
        private void UpdateQueueListBox()
        {
            listBoxQuque.Items.Clear();
            string queueInfo = hospitalQueue.DisplayQueue();
            // разделение строки queueInfo на массив подстрок для красивого и корректного ввывода в листбокс
            string[] patientInfoArray = queueInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            // добавляем информацию о пациентах в список очереди
            foreach (string patientInfo in patientInfoArray)
            {
                listBoxQuque.Items.Add(patientInfo);
            }
        }

        private void SerializeToJsonBtn_Click(object sender, EventArgs e)
        {
            string filePath = "hospitalQueue.json";
            hospitalQueue.SerializeToJson(filePath);

        }

        private void DeserializeFromJsonBtn_Click(object sender, EventArgs e)
        {
            string filePath = "hospitalQueue.json";
            HospitalQueue deserializedQueue = HospitalQueue.DeserializeFromJson(filePath);
            hospitalQueue = deserializedQueue;
            UpdateQueueListBox();

        }

        private void SerializeToBinaryBtn_Click(object sender, EventArgs e)
        {
            string filePath = "hospitalQueue.bin";
            hospitalQueue.SerializeToBinary(filePath);

        }

        private void DeserializeFromBin_Click(object sender, EventArgs e)
        {
            string filePath = "hospitalQueue.bin";
            HospitalQueue loadedQueue = HospitalQueue.DeserializeFromBinary(filePath);
            hospitalQueue = loadedQueue;
            UpdateQueueListBox();


        }



        private void SortAgeDelegate_Click(object sender, EventArgs e)
        {
            //соортировка очереди по возрасту с использованием делегата
            hospitalQueue.SortPatients(delegate (Patient p1, Patient p2)
            {
                return p1.Age.CompareTo(p2.Age);
            });
            UpdateQueueListBox();
        }

        private void SortIDLambda_Click(object sender, EventArgs e)
        {
            //  сортировква очереди по id с использованием лямбда-выражения           
            hospitalQueue.SortPatients((p1, p2) => p1.Id.CompareTo(p2.Id));
            UpdateQueueListBox();
        }

        private void SearchByLastNameLamda_Click(object sender, EventArgs e)
        {
            string searchValue = TBLastName.Text;
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                // поиск  по фамилии с использованием лямбда-выражения
                HospitalQueue filteredQueue = hospitalQueue.FilterPatients((p, search)
                => p.LastName.Contains(search), searchValue);
                //вывод в листбокс

                listBoxQuque.Items.Clear();
                string queueInfo = filteredQueue.DisplayQueue();
                // разделение строки queueInfo на массив подстрок для красивого и корректного ввывода в листбокс
                string[] patientInfoArray = queueInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                // добавляем информацию о пациентах в список очереди
                foreach (string patientInfo in patientInfoArray)
                {
                    listBoxQuque.Items.Add(patientInfo);
                }
            }
            else MessageBox.Show("Введите значение для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void SearchByNameDelegat_Click(object sender, EventArgs e)
        {
            string searchValue = TBFirstName.Text;
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                // поиск по имени с использованием делегата

                HospitalQueue filteredQueue = hospitalQueue.FilterPatients(delegate (Patient p, string search)
                {
                    return p.FirstName.Contains(search);
                }, searchValue);
                //вывод в листбокс

                listBoxQuque.Items.Clear();
                string queueInfo = filteredQueue.DisplayQueue();
                // разделение строки queueInfo на массив подстрок для красивого и корректного ввывода в листбокс
                string[] patientInfoArray = queueInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                // добавляем информацию о пациентах в список очереди
                foreach (string patientInfo in patientInfoArray)
                {
                    listBoxQuque.Items.Add(patientInfo);
                }
            }
            else MessageBox.Show("Введите значение для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

       

        private void lab10Btn_Click(object sender, EventArgs e)
        {
            if (newForm == null || newForm.IsDisposed)
            {
                newForm = new lab10();
                newForm.Show();
            }
            else
            {
                newForm.Activate();
            }
        }
    }
}