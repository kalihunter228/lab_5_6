using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_5_6
{
    public partial class vsp : Form
    {
        private string query;
        private string nameTable;
        private SQLiteConnection sc = new SQLiteConnection();
        private DataTable dt = new DataTable();
        private SQLiteDataAdapter a;

        public vsp(string nameF, string ConnectionString)
        {
            InitializeComponent();
            this.Text = nameF;
            this.Name = nameF;
            this.sc.ConnectionString = ConnectionString;
            sc.Open();

            switch (this.Name)
            {
                case "Квалификация":
                    {
                        query = "SELECT " +
                                "Qualification.qualification_id AS 'ID Квалификации', " +
                                "Qualification.qualification AS 'Квалификация' " +
                                "FROM Qualification;";
                        this.nameTable = "Квалификация";
                        break;
                    }
                case "Должность":
                    {
                        query = "SELECT " +
                                "Position.position_id AS 'ID Должности', " +
                                "Position.position AS 'Должность' " +
                                "FROM Position;";
                        this.nameTable = "Должность";
                        break;
                    }
                case "Направление":
                    {
                        query = "SELECT " +
                                "Direction.direction_id AS 'ID Направления', " +
                                "Direction.direction AS 'Направление' " +
                                "FROM Direction;";
                        this.nameTable = "Направление";
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Таблица не найдена.");
                        return;
                    }
            }
            a = new SQLiteDataAdapter(query, sc);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
