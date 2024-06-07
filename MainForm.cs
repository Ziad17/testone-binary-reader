using TestOne.BinaryReader.Maps;

namespace TestOne.BinaryReader
{
    public partial class MainForm : Form
    {
        private string _filePath;
        private bool _showReserved;

        public MainForm()
        {
            InitializeComponent();
            schemaComboBox.SelectedItem = nameof(BasicMap);
            SetupListViews();
            _filePath = "binary.bin";
            filePathLabel.Text = _filePath;
        }

        public void SetupListViews()
        {
            basicInfoListView.Clear();
            basicInfoListView.View = View.Details;

            basicInfoListView.Columns.Add("Type", 200, HorizontalAlignment.Left);
            basicInfoListView.Columns.Add("Title", 150, HorizontalAlignment.Left);
            basicInfoListView.Columns.Add("Value", 300, HorizontalAlignment.Left);

            testResultListView.Clear();
            testResultListView.View = View.Details;

            testResultListView.Columns.Add("Type", 130, HorizontalAlignment.Left);
            testResultListView.Columns.Add("Title", 150, HorizontalAlignment.Left);
            testResultListView.Columns.Add("Value", 130, HorizontalAlignment.Left);
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            var map = schemaComboBox.Text;
            testResultListView.Items.Clear();
            basicInfoListView.Items.Clear();

            if (map == nameof(BasicMap))
            {
                var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                using System.IO.BinaryReader reader = new System.IO.BinaryReader(fileStream);

                basicInfoListView.View = View.Details;

                var basicTestSections = BasicMap.BasicTests();
                var ratioTestsSections = BasicMap.RatioTests();

                foreach (var section in basicTestSections)
                {
                    reader.AnalyzeSection(ref fileStream, section);

                    var allocations = section.Allocations;

                    if (!_showReserved)
                    {
                        allocations = allocations.Where(c => !c.Reserved).ToList();
                    }

                    var items = allocations.Select(c =>
                        new ListViewItem(new[] { section.Name, c.Title, c.Value })).ToArray();

                    basicInfoListView.Items.AddRange(items);

                    basicInfoListView.Items.Add(new ListViewItem(new[] { "-", "-", "-" }));
                }

                foreach (var section in ratioTestsSections)
                {
                    reader.AnalyzeSection(ref fileStream, section);

                    var allocations = section.Allocations;

                    if (!_showReserved)
                    {
                        allocations = allocations.Where(c => !c.Reserved).ToList();
                    }

                    var items = allocations.Select(c =>
                        new ListViewItem(new[] { section.Name, c.Title, c.Value })).ToArray();

                    testResultListView.Items.AddRange(items);

                    testResultListView.Items.Add(new ListViewItem(new[] { "-", "-", "-" }));
                }
            }
            else
            {
                MessageBox.Show("could not read map");
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void showReserved_CheckedChanged(object sender, EventArgs e)
        {
            _showReserved = showReservedCheckBox.Checked;
        }

        private void fileOpened_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _filePath = openFileDialog1.FileName;
            filePathLabel.Text = _filePath;
        }
    }
}
