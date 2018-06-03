<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project.cs.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta charset="utf-8" />
    <meta name="author" content="Cullen Willis" />

    <title>Cherwell Application</title>

    <!-- styles for this template -->
    <link href="css/indexStyle.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="header">
            <div id="header-content">
                <p id="header-content-title">Cherwell Application</p>
                <p id="header-content-author">Cullen Willis</p>
            </div>
        </div>

        <div class="content">
            <div id="sketch-holder">
                <div id="canvas">
                    <asp:Image ID="ImageBox" CssClass="Image1" runat="server" />
                </div>

                <div id="text-V1">
                    <asp:TextBox ID="TextBoxV1x" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                    <asp:TextBox ID="TextBoxV1y" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                </div>

                <div id="text-V2">
                    <asp:TextBox ID="TextBoxV2x" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                    <asp:TextBox ID="TextBoxV2y" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                </div>

                <div id="text-V3">
                <asp:TextBox ID="TextBoxV3x" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                <asp:TextBox ID="TextBoxV3y" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>

                <asp:Button ID="ButtomSubmit" runat="server" Text="Button" OnClick="ButtomSubmit_Click" />
                </div>

                <asp:Label ID="Result" CssClass="resultLabel" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
