<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="DemoContact.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="CSS/style.css">
</head>
<body>
    <form id="form1" runat="server">
         <section id="contact">
            <p class="section_text_p1">Get in Touch</p>
            <h1 class="title">Contact Me</h1>

            <asp:TextBox ID="nameTextBox" runat="server" CssClass="contact-input" placeholder="Your name" Required="true"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="emailTextBox" runat="server" CssClass="contact-input" placeholder="Your email" Required="true" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="messageTextBox" runat="server" CssClass="contact-input" placeholder="Write message" TextMode="MultiLine" Rows="6" Required="true"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="txtSubmit" runat="server" Text="Send" OnClick="txtSubmit_Click" CssClass="contact-btn" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </section>
        <h2 class="heading">Contact<span>Me</span></h2>
            <section class="contact" id="contacts">


                <div>
                    <asp:TextBox runat="server" ID="name" placeholder="Fullname" CssClass="input-box" />

                </div>

                <div>
                    <asp:TextBox runat="server" ID="email" placeholder="Email" TextMode="Email" CssClass="input-box" />
                </div>

                <div>
                    <asp:TextBox runat="server" ID="phone" placeholder="Phone Number" TextMode="Phone" CssClass="input-box" />

                </div>
                <div>
                    <asp:TextBox runat="server" ID="subject" placeholder="Subject" CssClass="input-box" />
                </div>
                <asp:TextBox runat="server" ID="message" placeholder="Your Message to me" TextMode="MultiLine" CssClass="input-box" />
                <asp:Button runat="server" ID="Button1" Text="Send" CssClass="btn" OnClick="txtSubmit_Click" />

                <asp:Label runat="server" ID="lblError" Text="" />

            </section>
    </form>
</body>
</html>
