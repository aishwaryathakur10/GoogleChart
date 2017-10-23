<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Charts</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        </div>

        <div style="background-color:lightgrey";>
            <p style="text-align: center"><strong>LEAVE ANALYSIS </strong></p>
            <table style="background-color:#C4C6C6  ; border: 1px; margin: auto;">
                <div>
                    <tr>
                        <td style="padding-bottom: 20px">Select any date to check No of Employees on Leave for <strong>Particular Day</strong> :</td>
                        <td style="padding-bottom: 20px">Select Date:
                            <asp:TextBox ID="TxtDob" runat="server" TextMode="Date"></asp:TextBox></td>

                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Display" /></td>
                    </tr>
                </div>


                <div>
                    <tr>
                        <td style="padding-bottom: 20px">Choose Dates to Analyze Leaves <strong>over a Period:</strong> </td>
                        <td style="padding-bottom: 20px">Select start date:
             <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                            Select end date:
             <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                        </td>

                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Display" /></td>
                    </tr>
                </div>



                <div>

                    <tr>
                        <td style="padding-bottom: 20px">Select any date to check No of Employees on <strong>Half Day</strong> Leave for <strong>Particular Day</strong>  </td>
                        <td style="padding-bottom: 20px">Select Date:  
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox></td>

                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Display" /></td>
                    </tr>

                </div>


                <div>
                    <tr>
                        <td style="padding-bottom: 20px">Choose Dates to Analyze <strong>Half Day</strong> Leaves <strong>Over a Period</strong></td>
                        <td style="padding-bottom: 20px">Select start date:
             <asp:TextBox ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>
                            Select end date:
             <asp:TextBox ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox></td>

                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Display" /></td>
                    </tr>
                </div>


                <div>
                    <tr>
                        <td style="padding-bottom: 20px">Choose <strong>Month </strong>to display <strong>Monthly Leave Analysis</strong>  </td>
                        <td style="padding-bottom: 20px">Select Month: 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Display" /></td>
                    </tr>

                </div>



                <div>
                    <tr>
                        <td style="padding-bottom: 20px">Choose <strong>YEAR</strong> to display <strong>YEARLY Leave Analysis</strong> </td>
                        <td style="padding-bottom: 20px">Select Year:<asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        </asp:DropDownList></td>
                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Display" />
                        </td>
                    </tr>
                </div>



                <div>
                    <tr>
                        <td style="padding-bottom: 20px">Leave Analysis For a <strong>Particular Department</strong> on a <strong>Particular Day:</strong></td>
                        <td style="padding-bottom: 20px">Select Department :
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem Text="MGT" Value="24"></asp:ListItem>
            <asp:ListItem Text="HCM" Value="25"></asp:ListItem>
            <asp:ListItem Text="EBS" Value="26"></asp:ListItem>
            <asp:ListItem Text="ECS" Value="27"></asp:ListItem>
            <asp:ListItem Text="REC" Value="28"></asp:ListItem>
            <asp:ListItem Text="FNA" Value="29"></asp:ListItem>
            <asp:ListItem Text="SLM" Value="30"></asp:ListItem>
            <asp:ListItem Text="ITS" Value="31"></asp:ListItem>
            <asp:ListItem Text="Staff" Value="32"></asp:ListItem>
        </asp:DropDownList>

                            Select Date:   
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Display" /></td>
                    </tr>
                </div>


                <div>
                    <tr>
                        <td style="padding-bottom: 20px"><strong>In form of BAR CHART</strong>
                            Leave Analysis according to <strong>DEPARTMENTS</strong></td>
                        <td style="padding-bottom: 20px">Select Date: 
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="Date"></asp:TextBox></td>

                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Display" />
                        </td>
                    </tr>
                </div>




                <div>
                    <tr>
                        <td style="padding-bottom: 20px"><strong>In form of PIE CHART</strong>
                            Leave Analysis according to <strong>DEPARTMENTS</strong> </td>
                        <td style="padding-bottom: 20px">Select Date:
                            <asp:TextBox ID="TextBox8" runat="server" TextMode="Date"></asp:TextBox></td>

                        <td style="padding-bottom: 20px">
                            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Display" />
                        </td>
                    </tr>
                </div>
            </table>



            <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
            <br /><br />
            <div style="text-align: center"> <strong>BAR CHART</strong></div>
            <div id="chart_div" style="width: 1113px; height: 900px; background-color:#C4C6C6; margin:auto">
            </div>
            <div style="text-align: center"> <strong>PIE CHART</strong></div>
            <div id="piechart_3d" style="width: 1113px; height: 900px; margin:auto">
            </div>

        </div>
    </form>
</body>
</html>
