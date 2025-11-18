namespace finalProjectJA_2025
{
    public partial class LabiryntManagement : Form
    {
        private int[] intCellSize = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        private int[] intTableSize = new int[255];

        private int maxCoreNumber;

        public LabiryntManagement()
        {
            InitializeComponent();

            for (int i = 0; i < intCellSize.Length; i++)
            {
                comboBoxCellSize.Items.Add(intCellSize.GetValue(i));
            }

            maxCoreNumber = 1;

            for (int i = 1; i < 65; i++)
            {
                comboBoxCoresNumber.Items.Add(i);
            }

            for (int i = 0; i < intTableSize.Length; i++)
            {
                intTableSize[i] = i + 1;
            }

            for (int i = 0; i < intTableSize.Length; i++)
            {
                comboBoxWidth.Items.Add(intTableSize.GetValue(i).ToString());
                comboBoxHeight.Items.Add(intTableSize.GetValue(i).ToString());
            }

            comboBoxHeight.Text = intTableSize[4].ToString();
            comboBoxWidth.Text = intTableSize[4].ToString();

            comboBoxCellSize.Text = intCellSize[4].ToString();
            comboBoxCoresNumber.Text = "1";

        }

        private void comboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCellSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCoresNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
