using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace test01.Models {

    public class Query {
        string connString = @"server=127.0.0.1;port=3306;user id=root;password=1234;database=test01;charset=utf8;";
        MySqlConnection conn = new MySqlConnection();
        
        public bool conn_open() {
            conn.ConnectionString = connString;
            if(conn.State != ConnectionState.Open )
                conn.Open();
            string sql = @"INSERT INTO `City` (`Id`, `City`) VALUES
                           ('0', '基隆市'),
                           ('1', '臺北市'),
                           ('2', '新北市'),
                           ('3', '桃園市'),
                           ('4', '新竹市'),
                           ('5', '新竹縣'),
                           ('6', '宜蘭縣'),
                           ('7', '苗栗縣'),
                           ('8', '臺中市'),
                           ('9', '彰化縣'),
                           ('A', '南投縣'),
                           ('B', '雲林縣'),
                           ('C', '嘉義市'),
                           ('D', '嘉義縣'),
                           ('E', '臺南市'),
                           ('F', '高雄市'),
                           ('G', '屏東縣'),
                           ('H', '澎湖縣'),
                           ('I', '花蓮縣'),
                           ('J', '臺東縣'),
                           ('K', '金門縣'),
                           ('L', '連江縣');
";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int index = cmd.ExecuteNonQuery();
            bool success = false;
            if(index > 0)
                success = true;
            conn.Close();
            return success;
        }

        public DataTable Output() {
            conn.ConnectionString = connString;
            string sql = @"SELECT `id` , `city` FROM `city`";

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            return dt;

        }

    }

}
