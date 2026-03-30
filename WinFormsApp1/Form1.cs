using static WinFormsApp1.Drinks;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<Beverage> beveragesList = new List<Beverage>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.beveragesList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        this.beveragesList.Add(Juice.Generate());
                        break;
                    case 1:
                        this.beveragesList.Add(Soda.Generate());
                        break;
                    case 2:
                        this.beveragesList.Add(Alcohol.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int juicesCount = 0;
            int sodasCount = 0;
            int alcoholsCount = 0;

            string queueStr = "Очередь: ";

            foreach (var beverage in this.beveragesList)
            {
                if (beverage is Juice)
                {
                    juicesCount += 1;
                    queueStr += "[С] ";
                }
                else if (beverage is Soda)
                {
                    sodasCount += 1;
                    queueStr += "[Г] ";
                }
                else if (beverage is Alcohol)
                {
                    alcoholsCount += 1;
                    queueStr += "[А] ";
                }
            }

            if (beveragesList.Count == 0)
                queueStr = "Очередь пуста";

            txtInfo.Text = "Сок\tГазировка\tАлкоголь";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t\t{2}", juicesCount, sodasCount, alcoholsCount);
            txtInfo.Text += "\n\n" + queueStr;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.beveragesList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                return;
            }

            var beverage = this.beveragesList[0];
            this.beveragesList.RemoveAt(0);

            txtOut.Text = beverage.GetInfo();

            ShowInfo();
        }
    }
}