<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link rel="stylesheet" href="/CSS/Homepage.css" type="text/css" runat="Server" />
    <br />
    <div id="gallery">
        <div class="slideshow-container">

            <div class="mySlides fade">
                <div class="numbertext">1 / 3</div>
                <img src="Images/Door_1.png" style="width: 100%">
                <div class="text"><a href="Products_Gallery.aspx" style="text-decoration: none; color: white">Sleek Door Design</a></div>
            </div>

            <div class="mySlides fade">
                <div class="numbertext">2 / 3</div>
                <img src="Images/Door_2.png" style="width: 100%">
                <div class="text"><a href="Products_Gallery.aspx" style="text-decoration: none; color: white">Modern Door Design</a></div>
            </div>

            <div class="mySlides fade">
                <div class="numbertext">3 / 3</div>
                <img src="Images/Door_3.png" style="width: 100%">
                <div class="text"><a href="Products_Gallery.aspx" style="text-decoration: none; color: white">Traditional Door Design</a></div>
            </div>

            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
            <a class="next" onclick="plusSlides(1)">&#10095;</a>

        </div>
        <br>

        <div style="text-align: center">
            <span class="dot" onclick="currentSlide(1)"></span>
            <span class="dot" onclick="currentSlide(2)"></span>
            <span class="dot" onclick="currentSlide(3)"></span>
        </div>

        <script>
            var slideIndex = 1;
            showSlides(slideIndex);

            function plusSlides(n) {
                showSlides(slideIndex += n);
            }

            function currentSlide(n) {
                showSlides(slideIndex = n);
            }

            function showSlides(n) {
                var i;
                var slides = document.getElementsByClassName("mySlides");
                var dots = document.getElementsByClassName("dot");
                if (n > slides.length) { slideIndex = 1 }
                if (n < 1) { slideIndex = slides.length }
                for (i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }
                for (i = 0; i < dots.length; i++) {
                    dots[i].className = dots[i].className.replace(" active", "");
                }
                slides[slideIndex - 1].style.display = "block";
                dots[slideIndex - 1].className += " active";
            }
        </script>
    </div>
    <div id="company_desc">
            <h2>Garage Door Repairs</h2>

            <p>
                We’ve been serving the South Jersey area for the past 25 years! Find exactly what you’re looking for from our wide selection of garage doors! We also provide an installation service! Order today!
            </p>

            <p>
                In a professional context it often happens that private or corporate clients corder a publication to be made and presented with the actual content still not being ready. Think of a news blog that's filled with content hourly on the day of going live. However, reviewers tend to be distracted by comprehensible content, say, a random text copied from a newspaper or the internet. The are likely to focus on the text, disregarding the layout and its elements. Besides, random text risks to be unintendedly humorous or offensive, an unacceptable risk in corporate environments. <strong>Lorem ipsum</strong> and its many variants have been employed since the early 1960ies, and quite likely since the sixteenth century.
            </p>
    </div>
    <br />
</asp:Content>
