using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part2
{
    //I, Manan Patel, 000826892 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
    public partial class Form1 : Form
    {
        public SqlConnection Connection { get; private set; }
        
        String connectionString = @"Data Source=.\SQLEXPRESS;" +
                                   "Initial Catalog=COMP10204_FINAL;" +
                                   "Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            try
            {
                Connection = new SqlConnection(); //create new instance of SQLconnection
                Connection.ConnectionString = connectionString;
                Connection.Open(); //open the connection
                statuslabel1.Text = "Connected to Database Successfully"; //show message if connection is successful
            }
            catch (Exception ex) //catches any exceptions if connection fails
            {
                statuslabel1.Text = "Database Connection failed - check Connection String : " +
                ex.Message;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } 

        private void datalistView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {


                string SQL = "SELECT Movie.ReleaseYear, Movie.Title, Ship.ShipName,Movie.RunTime FROM Movie INNER JOIN Ship ON Movie.MovieID = Ship.MovieID order by ReleaseYear desc";


                try
                { 
                    SqlCommand sqlcommand = new SqlCommand(SQL, Connection);

                    // Create new SqlDataReader object and read data from the command.
                    SqlDataReader reader = sqlcommand.ExecuteReader();
                    if (reader != null)
                    {
                        // DBTableListView.View = View.Details;
                        datalistView1.FullRowSelect = true;

                        datalistView1.Columns.Clear();
                        datalistView1.Items.Clear();

                        for (int column = 0; column < reader.FieldCount; column++)
                            datalistView1.Columns.Add(reader.GetName(column), 100, HorizontalAlignment.Left);

                        int count = 0;
                        while (reader.Read())   // Gets another record 
                        {
                            ListViewItem lvi = new ListViewItem();
                            for (int column = 0; column < reader.FieldCount; column++) // 2nd to Last column 
                            {
                                string columnData = "null";
                                if (!reader.IsDBNull(column))
                                {
                                    Type ft = reader.GetFieldType(column);
                                    if (ft == typeof(string))
                                        columnData = reader.GetString(column);
                                    else if (ft == typeof(double))
                                        columnData = reader.GetDouble(column).ToString();
                                    else if (ft == typeof(int))
                                        columnData = reader.GetInt32(column).ToString();
                                    else if (ft == typeof(bool))
                                        columnData = reader.GetBoolean(column).ToString();
                                    else if (ft == typeof(DateTime))
                                        columnData = reader.GetDateTime(column).ToString();
                                }
                                if (column == 0)
                                    lvi.Text = columnData;
                                else
                                    lvi.SubItems.Add(columnData);
                            }
                            datalistView1.Items.Add(lvi);
                            count++;
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error in SQL " + SQL);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in SQL " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please Select the method to Print data");
            }
            }

        }
    }

