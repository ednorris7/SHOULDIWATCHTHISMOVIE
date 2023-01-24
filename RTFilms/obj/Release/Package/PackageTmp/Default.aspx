<%@ Page Title="Should I Watch This Movie?" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BigMovies._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="https://www.freeiconspng.com/thumbs/letter-m-icon-png/letter-m-icon-png-16.png"/>
    
    <style type="text/css">
        body {
            background-color: black;
        }

        h1 {
            color: white;
            text-align: center;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            font-size: 65px;
        }

        #form1 {
            text-align: center;
        }

        .button {
            background-color: white;
            color: black;
            font-size: 18px;
            padding: 10px 20px;
            border: double;
            border-radius: 4px;
        }

        .button:hover {
            background-color: black;
            color: white;
            font-size: 18px;
            padding: 10px 20px;
            border: double;
            border-radius: 4px;
        }

        #txtSearch {
            background-color: black;
            color: white;
            font-size: 18px;
            padding: 10px 30px;
            border: 2px solid white;
            border-radius: 4px;
        }
        
        #GridView1 {
            border: none !important;
            color: white;
            margin: 0 auto;
            margin-top: 70px;
            margin-bottom: 70px;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }

        #para {
            color: white;
            text-align: center;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            font-size: 40px;
            margin-top: 70px;
            margin-left: 200px;
            margin-right: 200px;
        }
    </style>
    <title>Should I Watch This Movie?</title>
</head>
<body>
    <table style="width: 500px; height: 50px;" class="gridview">
    </table>
    <h1>Should I Watch This Movie?</h1>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button class="button" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" GridLines="None" BorderStyle="None" style="width: 1300px; height: 170px; font-size: 50px"/>
        </div>
        <div>
            <asp:Button class="button" ID="Alg" runat="server" Text="Analyse" OnClick="alg_Click" Visible="false"/>
        </div>
        <div id="para">
            <%=analysis %>
        </div>
    </form>
 
</body>
</html>
