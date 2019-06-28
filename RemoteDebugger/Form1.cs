using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int SERVER_PORT = 4824;
        bool AUTO_SCROLL = true;
        String SERVER_IP;
        int errors;
        int warnings;
        int successes;
        int infos;
        public void Server()
        {
            string chunk = "";
            UdpClient server = new UdpClient(SERVER_PORT);
            while (true)
            {
                // Get Client Information
                IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
                // Get Payload
                string payload = Encoding.ASCII.GetString(server.Receive(ref client));

                if (payload.Length > 0)
                {
                    // Add payload to a buffer
                    chunk += payload;
                    // Check if buffer contains a new line indicating the payload is ready to log
                    if (chunk.Contains("\n"))
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            // Split the payload into lines
                            string[] chunks = chunk.Split('\n');
                            // Loop through each line
                            for (int i = 0; i < chunks.Length; i++)
                            {
                                // Remove any whitespace
                                string line = chunks[i].Trim();
                                // Make sure line isnt empty
                                if (line.Length > 0)
                                {
                                    // Build each cell in the row
                                    string[] cells = new string[4];
                                    cells[0] = DateTime.Now.ToString("h:mm:ss tt"); // Time
                                    cells[1] = String.Format("{0}:{1}", client.Address, client.Port); // Device IP and Port
                                    cells[2] = line.Split('[', ']')[1]; // Status
                                    cells[3] = line.Replace("[" + cells[2] + "] ", ""); // Message
                                    // Create Row
                                    ListViewItem lvi = new ListViewItem(cells);
                                    switch (cells[2])
                                    {
                                        case "ERROR": // Line format for errors
                                            lvi.ForeColor = System.Drawing.Color.Red;
                                            Font f = new Font(lvi.Font, FontStyle.Bold);
                                            lvi.Font = f;
                                            errors++;
                                            break;
                                        case "OK": // Line format for success
                                            lvi.ForeColor = System.Drawing.Color.DarkGreen;
                                            successes++;
                                            break;
                                        case "WARN": // Line format for success
                                            lvi.ForeColor = System.Drawing.Color.Orange;
                                            warnings++;
                                            break;
                                        case "INFO": // Line format for JSON
                                            lvi.ForeColor = System.Drawing.Color.LightSlateGray;
                                            infos++;
                                            break;
                                    }
                                    // Insert new row into the log
                                    log.Items.Add(lvi);

                                    // AutoScroll to the bottom
                                    if (AUTO_SCROLL)
                                    {
                                        log.Items[log.Items.Count - 1].EnsureVisible();
                                    }
                                    label1.Text = String.Format("Error: {0} Warn: {1} Info: {2} Success: {3}", errors, warnings, infos, successes);
                                    // Clear buffer
                                    chunk = "";
                                }
                            }
                        });
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    SERVER_IP = ip.ToString();
                    break;
                }
            }
            // Enable Auto Scroll
            autoScroll.Checked = AUTO_SCROLL;

            // Add column header
            log.View = View.Details;
            log.GridLines = true;
            log.FullRowSelect = true;
            log.Columns.Add("Time", 75);
            log.Columns.Add("Device", 100);
            log.Columns.Add("Status", 60);
            log.Columns.Add("Message", this.Width - 254 - 42);
            log.KeyDown += ListBox1_KeyDown;
            this.Resize += Log_Resize;

            // Trick to increase row height
            ImageList imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(1, 30);
            log.SmallImageList = imgList;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the Server
            Thread client = new Thread(new ThreadStart(Server));
            client.IsBackground = true;
            client.Start();
        }

        // Makes the table look cleaner
        private void Log_Resize(object sender, EventArgs e)
        {
            log.Columns[3].Width = this.Width - 254 - 42;
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            warnings = 0;
            infos = 0;
            successes = 0;
            errors = 0;
            log.Items.Clear();
            label1.Text = String.Format("Error: {0} Warn: {1} Info: {2} Success: {3}", errors, warnings, infos, successes);
        }
        private void ListBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                ListView.SelectedListViewItemCollection selectedItems = log.SelectedItems;
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    text += String.Format("[{0}]\t{1}\n", item.SubItems[2].Text, item.SubItems[3].Text);
                }
                Clipboard.SetText(text);
            }
        }

        private void RebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = log.SelectedItems;
            if (selectedItems.Count > 0)
            {
                String device = selectedItems[0].SubItems[1].Text;
                String ip = device.Split(':')[0].ToString();
                int port = Int32.Parse(device.Split(':')[1]);
                UdpClient client = new UdpClient();
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
                client.Connect(ep);
                byte[] b = { 0x86 };
                client.Send(b, sizeof(byte));
                client.Close();
            }
            else
            {
                MessageBox.Show("No device was selected", "Oops!");
            }
        }

        private void AutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            AUTO_SCROLL = autoScroll.Checked;
        }

        private void SvrAddress_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Edit your configuration.h file with the information provided below\n\n#define DEBUG_HOST \"{0}\"", SERVER_IP), "configuration.h");
        }
    }
}