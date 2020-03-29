<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link rel="stylesheet" href="/CSS/Contact_Us.css" type="text/css" runat="Server" />

    <div id="contact_message">
        <div class="container">
            <div style="text-align: center">
                <h2>Contact Us</h2>
                <p><b>Address:</b> 712 Delsea Dr. Glassboro, NJ 08028</p>
                <p><b>Email:</b> glassbororepair@yahoo.com <b>Phone:</b> 267-414-1515</p>
            </div>
            <div class="row">
                <div class="column">
                    <img src="/Images/Door_1.png" style="width: 100%">
                </div>
                    <br />
                <div class="column">
                    <form action="/action_page.php">
                        <label for="fname">Full Name</label>
                        <input type="text" id="fname" name="fullname" placeholder="Your full name..">
                        <label for="email">Email Address</label>
                        <input type="text" id="email" name="email" placeholder="Ex: johndoe@gmail.com">
                        <label for="phone">Phone Number</label>
                        <input type="text" id="phone" name="phone" placeholder="Ex: #856-420-6969">
                        <label for="state">State</label>
                        <select id="state" name="state">
                            <option value="new_jersey">New Jersey</option>
                            <option value="new_york">New York</option>
                            <option value="delaware">Delaware</option>
                            <option value="pennsylvania">Pennsylvania</option>
                        </select>
                        <label for="subject">Subject</label>
                        <textarea id="subject" name="subject" placeholder="Detail your request.." style="height: 170px"></textarea>
                        <input type="submit" value="Submit">
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
