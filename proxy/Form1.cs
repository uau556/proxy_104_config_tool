using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace proxy
{
    public partial class Form1 : Form
    {
        //IniFile iniFile = new IniFile(@"C:\Data\104proxy\config.ini");

        public Form1()
        {
            InitializeComponent();
            fill_combo_with_pairs();
            fill_combo_with_channels(comboBox2.Text);
            check_db(comboBox2.Text, comboBox1.Text);
            check_ip_ifs_and_ext_proxy(comboBox2.Text);
            fill_config_textbox();
        }

        private void fill_combo_with_pairs()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("6");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("8");
            comboBox2.SelectedIndex = 0;
        }


        private void fill_combo_with_channels(string pair)
        {
            //string hostname = iniFile.GetValue("general", "hostnaam", "test");
            string hostname = "ola0032";
            //MessageBox.Show(hostname);
            var cs = "Host=" + hostname + ";Username=postgres;Password=mysecretpassword;Database=postgres";
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            try {
                toolStripStatusLabel1.Text = "Connectie gemaakt met host " + hostname;
                conn.Open();

                if (!String.IsNullOrEmpty(pair))
                {

                    NpgsqlCommand command = new NpgsqlCommand("SELECT channel_sp FROM proxy_config where pair_sp = " + pair + " order by 1", conn);

                    NpgsqlDataReader dr = command.ExecuteReader();

                    //MessageBox.Show(dr.HasRows.ToString());

                    comboBox1.Items.Clear();

                    if (dr.HasRows)
                    {
                        // Output rows

                        while (dr.Read())
                        {
                            Console.Write("{0}\n", dr[0]);
                            comboBox1.Items.Add(dr[0].ToString());
                        }


                    }
                    else
                    {
                        comboBox1.Items.Add("1001");
                    }
                    comboBox1.SelectedIndex = 0;
                }
                conn.Close();
            }
            catch (Exception e)
            {
                toolStripStatusLabel1.Text = "Kan geen connectie maken met de database";

                Console.Write( e.Message);
            }
        }



        private void check_db(string pair, string channel)
        {
            //string hostname = iniFile.GetValue("general", "hostnaam", "test");
            string hostname = "ola0032";

            var cs = "Host=" + hostname + ";Username=postgres;Password=mysecretpassword;Database=postgres";
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            conn.Open();

            if (!String.IsNullOrEmpty(pair))
            {
                if (!String.IsNullOrEmpty(channel))
                {
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM proxy_config where pair_sp = " + pair + " and channel_sp =" + channel, conn);

                    NpgsqlDataReader dr = command.ExecuteReader();

                    //MessageBox.Show(dr.HasRows.ToString());

                    if (dr.HasRows)
                    {
                        // Output rows
                        while (dr.Read())
                        {
                            Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8} \n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
                            textBox1.Text = dr[3].ToString();
                            textBox7.Text = dr[4].ToString();
                            textBox3.Text = dr[5].ToString();
                            textBox4.Text = dr[6].ToString();
                            textBox5.Text = dr[7].ToString();
                            textBox6.Text = dr[8].ToString();
                        }

                    }
                    else
                    {
                        if (radioButton1.Checked)
                        {
                            textBox1.Text = "10.16.";
                        }
                        else
                        {
                            textBox1.Text = "10.20.";
                        }
                        textBox7.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";

                    }
                }
            }
            conn.Close();

        }

        private void check_ip_ifs_and_ext_proxy(string value)
        {
            if (value.Equals("1"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.100.2";
                    textBox8.Text = "10.16.166.1";
                }
                else
                {
                    textBox9.Text = "10.21.100.2";
                    textBox8.Text = "10.20.166.1";
                }
            }
            if (value.Equals("2"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.100.3";
                    textBox8.Text = "10.16.166.2";
                }
                else
                {
                    textBox9.Text = "10.21.100.3";
                    textBox8.Text = "10.20.166.2";
                }
            }
            if (value.Equals("3"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.100.4";
                    textBox8.Text = "10.16.166.3";
                }
                else
                {
                    textBox9.Text = "10.21.100.4";
                    textBox8.Text = "10.20.166.3";
                }
            }
            if (value.Equals("4"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.100.5";
                    textBox8.Text = "10.16.166.4";
                }
                else
                {
                    textBox9.Text = "10.21.100.5";
                    textBox8.Text = "10.20.166.4";
                }
            }
            if (value.Equals("5"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.100.6";
                    textBox8.Text = "10.16.166.5";
                }
                else
                {
                    textBox9.Text = "10.21.100.6";
                    textBox8.Text = "10.20.166.5";
                }
            }
            if (value.Equals("6"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.100.7";
                    textBox8.Text = "10.16.166.6";
                }
                else
                {
                    textBox9.Text = "10.21.100.7";
                    textBox8.Text = "10.20.166.6";
                }
            }
            if (value.Equals("7"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.17.108.1";
                    textBox8.Text = "10.16.166.7";
                }
                else
                {
                    textBox9.Text = "10.17.108.2";
                    textBox8.Text = "10.20.166.7";
                }
            }
            if (value.Equals("8"))
            {
                if (radioButton1.Checked)
                {
                    textBox9.Text = "10.88.209.1";
                    textBox8.Text = "10.84.134.14";
                    // 10.84.96.14 for rtu's
                }
                else
                {
                    textBox9.Text = "10.88.209.2";
                    textBox8.Text = "10.84.134.15";
                    // 10.84.96.15 for rtu's
                }
            }
            string String = textBox1.Text.Substring(5);
            if (radioButton1.Checked)
            {
                textBox1.Text = "10.16" + String;
            }
            else
            {
                textBox1.Text = "10.20" + String;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void fill_config_textbox()
        {
            richTextBox1.Clear();

            richTextBox1.AppendText("cli\n");
            richTextBox1.AppendText("  iec104proxy\n");
            richTextBox1.AppendText("     cc CS_" + comboBox1.Text + "\n");
            if (checkBox1.Checked)
            {
                richTextBox1.AppendText("      configure on\n");
            }
            richTextBox1.AppendText("      transparent no\n");
            richTextBox1.AppendText("      tcp-dir in\n");
            richTextBox1.AppendText("      enabled yes\n");
            richTextBox1.AppendText("      ipaddress " + textBox9.Text + "\n");
            richTextBox1.AppendText("      port 2404\n");
            richTextBox1.AppendText("      interface NONE\n");
            richTextBox1.AppendText("      main-fwd-dst no\n");
            richTextBox1.AppendText("      nexthop 0.0.0.0\n");
            richTextBox1.AppendText("      connect-from 0.0.0.0\n");
            richTextBox1.AppendText("      arp-from 0.0.0.0\n");
            richTextBox1.AppendText("      local-ipaddress " + textBox1.Text + "\n");
            richTextBox1.AppendText("      local-port 2404\n");
            richTextBox1.AppendText("      filter-control-dir NONE\n");
            richTextBox1.AppendText("      filter-monitoring-dir NONE\n");
            richTextBox1.AppendText("      startdt-dir in\n");
            richTextBox1.AppendText("      t0 30\n");
            richTextBox1.AppendText("      t1 15\n");
            richTextBox1.AppendText("      t2 10\n");
            richTextBox1.AppendText("      t3 20\n");
            richTextBox1.AppendText("      k 12\n");
            richTextBox1.AppendText("      w 8\n");
            richTextBox1.AppendText("      coalength 2\n");
            richTextBox1.AppendText("      ioalength 3\n");
            richTextBox1.AppendText("      cotlength 2\n");
            richTextBox1.AppendText("      vrtu-address-get-status 0\n");
            richTextBox1.AppendText("      vrtu-delaytime 0\n");
            richTextBox1.AppendText("      vrtu-address-get-delay 0\n");
            richTextBox1.AppendText("      vrtu-address-get-listener 0\n");
            richTextBox1.AppendText("      vrtu-address-set-listener 0\n");
            richTextBox1.AppendText("      tls off\n");
            richTextBox1.AppendText("      local-cert NONE\n");
            richTextBox1.AppendText("      require-cn NONE\n");
            richTextBox1.AppendText("      configure off\n");
            richTextBox1.AppendText("      exit\n");
            richTextBox1.AppendText("    rtu R_" + textBox7.Text + "_" + comboBox1.Text + "\n");
            if (checkBox1.Checked)
            {
                richTextBox1.AppendText("      configure on\n");
            }
            richTextBox1.AppendText("      enabled no\n");
            richTextBox1.AppendText("      ipaddress " + textBox3.Text + "\n");
            richTextBox1.AppendText("      connect-from " + textBox8.Text + "\n");
            richTextBox1.AppendText("      t1 " + textBox4.Text + "\n");
            richTextBox1.AppendText("      t2 " + textBox5.Text + "\n");
            richTextBox1.AppendText("      t3 " + textBox6.Text + "\n");
            richTextBox1.AppendText("      configure off\n");
            richTextBox1.AppendText("      exit\n");
            richTextBox1.AppendText("    link LS_" + comboBox1.Text + "\n");
            if (checkBox1.Checked)
            {
                richTextBox1.AppendText("      configure on\n");
            }
            richTextBox1.AppendText("      cc CS_" + comboBox1.Text + "\n");
            richTextBox1.AppendText("      rtu R_" + textBox7.Text + "_" + comboBox1.Text + "\n");
            richTextBox1.AppendText("      configure off\n");
            richTextBox1.AppendText("    exit\n");
            richTextBox1.AppendText("  exit\n");
            richTextBox1.AppendText("exit\n");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private static void AddText(Stream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    AddText(myStream, richTextBox1.Text);
                    myStream.Close();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            check_ip_ifs_and_ext_proxy(comboBox2.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            check_ip_ifs_and_ext_proxy(comboBox2.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IPAddress ip;

            if (IPAddress.TryParse(textBox1.Text, out ip))
            {
                textBox1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                textBox1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Ip adres formaat niet juist";
            }

            fill_config_textbox();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            IPAddress ip;

            if (IPAddress.TryParse(textBox3.Text, out ip))
            {
                textBox3.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                textBox3.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Ip adres formaat niet juist";
            }
            fill_config_textbox();
        }
        
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            fill_config_textbox();
            int minVal = 1000;
            int maxVal = 4000;
            if (!comboBox1.Text.Equals("")) {
                int Val = Int32.Parse(comboBox1.Text);
                Console.Write(Val.ToString());
                if (Val > minVal & Val < maxVal)
                {
                    comboBox1.ForeColor = Color.Black;
                    toolStripStatusLabel1.Text = "";
                }
                else
                {
                    comboBox1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "Channel tussen 1000 en 4000";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Write(comboBox1.SelectedIndex);
            check_db(comboBox2.Text, comboBox1.SelectedItem.ToString());
            check_ip_ifs_and_ext_proxy(comboBox2.Text);
            fill_config_textbox();
            int minVal = 1000;
            int maxVal = 4000;
            int Val = Int32.Parse(comboBox1.Text);
            if (Val > minVal & Val < maxVal)
            {
                comboBox1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                comboBox1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Channel tussen 1000 en 4000";
            }

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            string s1 = "1 2 3 4 5 6 7 8";
            string s2 = comboBox2.Text;
            bool b = s1.Contains(s2);
            if (b)
            {

                comboBox2.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "";
                fill_combo_with_channels(comboBox2.Text);
                check_ip_ifs_and_ext_proxy(comboBox2.Text);
                fill_config_textbox();

            }
            else
            {
                comboBox2.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Pair id tussen 1 en 8";
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = "1 2 3 4 5 6 7 8";
            string s2 = comboBox2.Text;

            bool b = s1.Contains(s2);
            //MessageBox.Show(b.ToString());
            if (b)
            {

                comboBox2.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "";
                fill_combo_with_channels(comboBox2.Text);
                check_ip_ifs_and_ext_proxy(comboBox2.Text);
                fill_config_textbox();

            }
            else
            {
                comboBox2.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Pair id tussen 1 en 8";
            }

        }

        private bool check_empty_field()
        {
            bool checked_fields = true;

            if (String.IsNullOrEmpty(textBox1.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox3.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox4.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox5.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox6.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox7.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox8.Text)) { checked_fields = false; }
            if (String.IsNullOrEmpty(textBox9.Text)) { checked_fields = false; }

            return checked_fields;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //string hostname = iniFile.GetValue("general", "hostnaam", "test");
            string hostname = "ola0032";
            var cs = "Host=" + hostname + ";Username=postgres;Password=mysecretpassword;Database=postgres";
            NpgsqlConnection conn = new NpgsqlConnection(cs);

            conn.Open();

            String pair = comboBox2.Text;
            String channel = comboBox1.Text;

            if (!String.IsNullOrEmpty(pair))
            {
                if (!String.IsNullOrEmpty(channel))
                {
                    NpgsqlCommand command = new NpgsqlCommand("SELECT count(*) FROM proxy_config where pair_sp = " + pair + " and channel_sp =" + channel, conn);

                    Int64 count = (Int64)command.ExecuteScalar();

                    String ip_fep_local_sp_a = "10.20" + textBox1.Text.Substring(5);
                    String ip_fep_local_sp_h = "10.16" + textBox1.Text.Substring(5);

                    if (check_empty_field())
                    {
                        if (count == 1)
                        {

                            //update
                            MessageBox.Show("Bestaand record dus Update");
                            String statement = "UPDATE proxy_config SET ip_fep_local_sp_a='" + ip_fep_local_sp_a + "', ";
                            statement = statement + "ip_fep_local_sp_h='" + ip_fep_local_sp_h + "', ";
                            statement = statement + "rtu_name='" + textBox7.Text + "', ";
                            statement = statement + "rtu_ip='" + textBox3.Text + "', ";
                            statement = statement + "rtu_t1='" + textBox4.Text + "', ";
                            statement = statement + "rtu_t2='" + textBox5.Text + "', ";
                            statement = statement + "rtu_t3='" + textBox6.Text + "' ";
                            statement = statement + " WHERE pair_sp=" + pair + " and channel_sp= " + channel;

                            //MessageBox.Show(statement);

                            NpgsqlCommand updatecommand = new NpgsqlCommand(statement, conn);
                            NpgsqlDataReader dataReader = updatecommand.ExecuteReader();
                        }
                        else
                        {
                            //insert
                            MessageBox.Show("Nieuw record dus insert");
                            String statement = "INSERT INTO proxy_config VALUES ( ";
                            statement = statement + pair + ", ";
                            statement = statement + channel + ", ";
                            statement = statement + "'" + ip_fep_local_sp_a + "', ";
                            statement = statement + "'" + ip_fep_local_sp_h + "', ";
                            statement = statement + "'" + textBox7.Text + "', ";
                            statement = statement + "'" + textBox3.Text + "', ";
                            statement = statement + textBox4.Text + ", ";
                            statement = statement + textBox5.Text + ", ";
                            statement = statement + textBox6.Text + ") ";

                            //MessageBox.Show(statement);

                            NpgsqlCommand updatecommand = new NpgsqlCommand(statement, conn);
                            NpgsqlDataReader dataReader = updatecommand.ExecuteReader();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Er is minstens 1 tekstveld leeg. Dat mag niet.");
                    }
                }
            }
            conn.Close();

            comboBox2.ForeColor = Color.Black;
            fill_combo_with_channels(comboBox2.Text);
            check_ip_ifs_and_ext_proxy(comboBox2.Text);
            fill_config_textbox();




        }

        private void button5_Click(object sender, EventArgs e)
        {


            var confirmResult = MessageBox.Show("Weet je het zeker ??",
                                     "Bevestig Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //delete the current sheet
                //string hostname = iniFile.GetValue("general", "hostnaam", "test");
                string hostname = "ola0032";
                var cs = "Host=" + hostname + ";Username=postgres;Password=mysecretpassword;Database=postgres";
                NpgsqlConnection conn = new NpgsqlConnection(cs);

                conn.Open();

                String pair = comboBox2.Text;
                String channel = comboBox1.Text;

                NpgsqlCommand command = new NpgsqlCommand("DELETE FROM proxy_config where pair_sp = " + pair + " and channel_sp =" + channel, conn);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                conn.Close();

                fill_combo_with_pairs();
                fill_combo_with_channels(comboBox2.Text);
                check_db(comboBox2.Text, comboBox1.Text);
                check_ip_ifs_and_ext_proxy(comboBox2.Text);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            fill_config_textbox();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            fill_config_textbox();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            fill_config_textbox();
        }
        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            fill_config_textbox();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fill_config_textbox();
        }
        public static uint ConvertFromIpAddressToInteger(string ipAddress)
        {
            var address = IPAddress.Parse(ipAddress);
            byte[] bytes = address.GetAddressBytes();

            // flip big-endian(network order) to little-endian
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static string ConvertFromIntegerToIpAddress(uint ipAddress)
        {
            byte[] bytes = BitConverter.GetBytes(ipAddress);

            // flip little-endian to big-endian(network order)
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return new IPAddress(bytes).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String pair = comboBox2.Text;

            //string hostname = iniFile.GetValue("general", "hostnaam", "test");
            string hostname = "ola0032";
            var cs = "Host=" + hostname + ";Username=postgres;Password=mysecretpassword;Database=postgres";
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            conn.Open();

            List<string> ips_int = new List<string>();
            List<string> ips_sorted = new List<string>();



            if (!String.IsNullOrEmpty(pair))
            {
               
                NpgsqlCommand command = new NpgsqlCommand("SELECT ip_fep_local_sp_a FROM proxy_config where pair_sp = " + pair + "ORDER BY 1", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                //MessageBox.Show(dr.HasRows.ToString());

                if (dr.HasRows)
                {
                    // Output rows
                    while (dr.Read())
                    {
                        Console.Write("{0}\n", dr[0]);
                        ips_int.Add(ConvertFromIpAddressToInteger(dr[0].ToString()).ToString() );

                        //ConvertFromIpAddressToInteger("255.255.255.254"); // 4294967294
                        //ConvertFromIntegerToIpAddress(4294967294); // 255.255.255.254
                    }

                } else
                {
                    MessageBox.Show("Nog geen ip adressen beschikbaar neem contact op met RE");
                }

                List<string> sorted = ips_int.OrderBy(ip => ip).ToList();
                Console.Write("---------------------\n");
                uint next_ip = 1;
                foreach (var ip in sorted)
                {
                    next_ip = Convert.ToUInt32(ip) + 1;
                    Console.WriteLine("{0}", ConvertFromIntegerToIpAddress(Convert.ToUInt32(ip ) ) );
                    ips_sorted.Add(ConvertFromIntegerToIpAddress(Convert.ToUInt32(ip)));
                }

                String next_ip_str = ConvertFromIntegerToIpAddress(next_ip);
                Console.Write("---------------------\n");
                Console.WriteLine("{0}", next_ip_str);
                textBox1.Text = next_ip_str;

                string String = textBox1.Text.Substring(5);
                if (radioButton1.Checked)
                {
                    textBox1.Text = "10.16" + String;
                }
                else
                {
                    textBox1.Text = "10.20" + String;
                }


                
            }
            conn.Close();







        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}