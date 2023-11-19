using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class lab10 : Form
    {
        public PatientTaskManager PatintQueue = new PatientTaskManager();
        public PatientTaskManager InitialQueue = new PatientTaskManager();

        public lab10()
        {
            InitializeComponent();
        }



        private async void GenerateBtn_Click(object sender, EventArgs e)
        {

            int thread1 = (int)numericUpDown1.Value;
            int thread2 = (int)numericUpDown2.Value;
            int thread3 = (int)numericUpDown3.Value;
            int thread4 = (int)numericUpDown4.Value;
            int summ = (int)numericUpDownSum.Value;
            if (thread1 == 0 && thread2 == 0 && thread3 == 0 && thread4 == 0)
                throw new Exception("Значения пусты");
            else if (thread1 + thread2 + thread3 + thread4 != summ)
            {
                MessageBox.Show("Заданое количество параметров не соответсвует сумме.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                List<int> patientsPerThread = new List<int> { thread1, thread2, thread3, thread4 };
                PatintQueue.GeneratePatientsInQueue(patientsPerThread);
                await PatintQueue.SerializeToJson("data.json");
                InitialQueue = PatintQueue;
            }

        }

        private async void SortBtn_Click(object sender, EventArgs e)
        {
            int[] threadCounts = { 1, 2, 4, 8 };

            foreach (int count in threadCounts)
            {
                PatintQueue.SortParallel(count);
                await PatintQueue.SerializeToJson($"sort{count}.json");
                PatintQueue = InitialQueue;

            }
            PatintQueue.SortNoParallel();
            await PatintQueue.SerializeToJson($"sortNoParallel.json");
            PatintQueue = InitialQueue;
        }
    }
}
