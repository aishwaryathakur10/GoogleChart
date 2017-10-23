using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }


        #endregion
        #region Particular Day
        #region Button1
        protected void Button1_Click(object sender, EventArgs e)
        {

            GetChartData();

            BindChart();
        }

        #endregion


        #region BindChart
        private void BindChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetChartData();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['AttendenceDate', 'eCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["AttendanceDate"] + "'," + row["eCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Attendance Date'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        #endregion



        #region GetChartData
        private DataTable GetChartData()
        {
            DataSet dsData = new DataSet();

            var dob = Request["TxtDob"];


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetDetail", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@absent", SqlDbType.DateTime).Value = dob;
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion

        #endregion


        #region Start-End Date

        #region Button_2
        protected void Button2_Click(object sender, EventArgs e)
        {
            GetPieChartData();

            BindPieChart();

        }
        #endregion


        #region GetPieChartData

        private DataTable GetPieChartData()
        {

            DataSet dsData = new DataSet();

            var dob = Request["TextBox1"];
            var dob1 = Request["TextBox2"];

            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetDetailPeriod", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@date1", SqlDbType.DateTime).Value = dob;
                sqlCmd.SelectCommand.Parameters.Add("@date2", SqlDbType.DateTime).Value = dob1;

                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }

        #endregion


        #region BindPieChart
        private void BindPieChart()
        {

            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetPieChartData();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['AttendanceDate', 'empCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["AttendanceDate"] + "'," + row["empCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Attendance Dates'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }
        #endregion


        #endregion



        #region Particular Day HalfDay

        #region Button3
        protected void Button3_Click(object sender, EventArgs e)
        {
            GetHalfDay();
            BindHalfDay();

        }

        #endregion

        #region GetHalfDay
        private DataTable GetHalfDay()
        {

            DataSet dsData = new DataSet();

            var dob = Request["TextBox3"];


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetHalfDayData", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@hLeave", SqlDbType.DateTime).Value = dob;

                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion

        #region BindHalfDay
        private void BindHalfDay()
        {

            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetHalfDay();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['AttendenceDate', 'eCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["AttendanceDate"] + "'," + row["eCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Attendance Date'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        #endregion

        #endregion


        #region HalfDay Timely
        #region Button4
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetHalfTimely();
            BindHalfTimely();

        }
        #endregion


        #region GetHalfTimely
        private DataTable GetHalfTimely()
        {

            DataSet dsData = new DataSet();

            var dob = Request["TextBox4"];
            var dob1 = Request["TextBox5"];

            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("HalfDayPeriod", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@date1", SqlDbType.DateTime).Value = dob;
                sqlCmd.SelectCommand.Parameters.Add("@date2", SqlDbType.DateTime).Value = dob1;

                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }

        #endregion



        #region BindHalfTimely
        private void BindHalfTimely()
        {

            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetHalfTimely();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['AttendenceDate', 'empCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["AttendanceDate"] + "'," + row["empCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Attendance Dates'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        #endregion

        #endregion



        #region Month
        protected void Button5_Click(object sender, EventArgs e)
        {

            GetMonth();

            BindMonth();
        }


        #region GetMonth
        private DataTable GetMonth()
        {
            DataSet dsData = new DataSet();

            var mon = Request["DropDownList1"];


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetMonth", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@month", SqlDbType.Int).Value = mon;
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion

        #region BindMonth
        private void BindMonth()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetMonth();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['AttendenceDate', 'mcount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["AttendanceDate"] + "'," + row["mcount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Days of the Month'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }
        #endregion


        #endregion


        #region Year
        protected void Button6_Click(object sender, EventArgs e)
        {

            GetYear();

            BindYear();
        }


        #region GetYear
        private DataTable GetYear()
        {
            DataSet dsData = new DataSet();

            var year = Request["DropDownList2"];


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetYearDetail", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion

        #region BindYear
        private void BindYear()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetYear();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['month', 'ycount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["month"] + "'," + row["ycount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Months of the year'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }
        #endregion


        #endregion



        #region Department
        protected void Button7_Click(object sender, EventArgs e)
        {

            GetDepartment();

            BindDepartment();
        }


        #region GetDepartment
        private DataTable GetDepartment()
        {
            DataSet dsData = new DataSet();

            var dept = Request["DropDownList3"];
            var absDt = Request["TextBox6"];

            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetDepartment", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@deptId", SqlDbType.Int).Value = dept;
                sqlCmd.SelectCommand.Parameters.Add("@absDate", SqlDbType.DateTime).Value = absDt;
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion

        #region BindDepartment
        private void BindDepartment()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetDepartment();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['DepartmentSName', 'eCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["DepartmentSName"] + "'," + row["eCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee in Department'},  hAxis: {title: 'Attendence Date'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }
        #endregion


        #endregion


        #region Department Detail


        #region Button8
        protected void Button8_Click(object sender, EventArgs e)
        {

            GetDeptDetail();

            BindDeptDetail();
        }

        #endregion


        #region BindDeptDetail
        private void BindDeptDetail()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetDeptDetail();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['DepartmentSName', 'eCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["DepartmentSName"] + "'," + row["eCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation', vAxis: {title: 'No of Employee'},  hAxis: {title: 'Departments'}, seriesType: 'bars', series: {3: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                //strScript.Append("var options = { title : 'Leave Statistics of organzation',   is3D: true, }; ");
                //strScript.Append(" var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        #endregion



        #region GetDeptDetail
        private DataTable GetDeptDetail()
        {
            DataSet dsData = new DataSet();

            var dob = Request["TextBox7"];


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetDeptDetail", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@absent", SqlDbType.DateTime).Value = dob;
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion

        #endregion



        #region Department Detail Pie


        #region Button9
        protected void Button9_Click(object sender, EventArgs e)
        {

            GetPieDeptDetail();

            BindPieDeptDetail();
        }

        #endregion


        #region BindPieDeptDetail
        private void BindPieDeptDetail()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetPieDeptDetail();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['DepartmentSName', 'eCount'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["DepartmentSName"] + "'," + row["eCount"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Leave Statistics of organzation',   is3D: true, }; ");
                strScript.Append(" var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));  chart.draw(data, options); } google.setOnLoadCallback(drawChart);");
                strScript.Append(" </script>");



                ltScripts.Text = strScript.ToString();



            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        #endregion



        #region GetPieDeptDetail
        private DataTable GetPieDeptDetail()
        {
            DataSet dsData = new DataSet();

            var dob = Request["TextBox8"];


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["BiometricEntities"].ToString());
                SqlDataAdapter sqlCmd = new SqlDataAdapter("GetDeptDetail", sqlCon);
                sqlCmd.SelectCommand.Parameters.Add("@absent", SqlDbType.DateTime).Value = dob;
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
        #endregion
        #endregion




    }

}
