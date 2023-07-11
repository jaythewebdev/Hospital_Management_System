import React from "react";
import './Landing.css'
import { Link } from "react-router-dom";

function Landing(){
    return (
        <div>
<div className="landing-container">
<section className="landing-sec">
<em>WELCOME TO HEALTHCARE</em>
<h1>Take the world's best quality Treatment</h1>
<h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</h4>
<Link to="/Login/" class="btn1">Learn More</Link>
</section>
</div>
{/* <!--SECTION2--> */}
<section class="section2">
<div class="cards">
<div class="card">
<i class="fa fa-medkit"></i>
<h1>Qualified Doctors</h1>
<p>Lorem ipsum amet, consectetur adipiscing elit, sed do eiusmod tempor cididunt facilisis.</p>
</div>
<div class="card">
<i class="fa fa-certificate"></i>
<h1>Certified Services</h1>
<p>Lorem ipsum amet, consectetur adipiscing elit, sed do eiusmod tempor cididunt facilisis.</p>
</div>
<div class="card">
<i class="fa fa-stethoscope"></i>
<h1>Advanced Equipment</h1>
<p>Lorem ipsum amet, consectetur adipiscing elit, sed do eiusmod tempor cididunt facilisis.</p>
</div>
<div class="card">
<i class="fa fa-heartbeat"></i>
<h1>Emergency Service</h1>
<p>Lorem ipsum amet, consectetur adipiscing elit, sed do eiusmod tempor cididunt facilisis.</p>
</div>
</div>
</section>

{/* <!--SECTION3--> */}
<section class="section3">
<div class="cards">
<div class="card">
<section>
<h1>Laboratory Services</h1>
<h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit</h4>
</section>
</div>
<div class="card">
<section>
<h1>General Treatment</h1>
<h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit</h4>
</section>
</div>
<div class="card">
<section>
<h1>Orthopedician</h1>
<h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit</h4>
</section>
</div>
</div>
<div class="content">
<h1>We are well experienced doctors</h1>
<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. </p>
</div>
</section>


{/* <!--FOOTER--> */}
<div>
<img src="https://i.ibb.co/ZLHbWJz/footer.png" class="footer_image"/>
<footer>
<div class="column">
<a class="footer_title">HEALTHCARE</a>
<a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</a>
<a href="#" title="Facebook"><i class="fab fa-facebook fa-lg"></i></a>
<a href="#" title="Instagram"><i class="fab fa-instagram fa-lg"></i></a>
<a href="#" title="Twitter"><i class="fab fa-twitter fa-lg"></i></a>
</div>
<div class="column">
<a class="footer_title">OTHER LINKS</a>
<a href="#">Privacy Policy</a>
<a href="#">Terms & Conditions</a>
<a href="#">Ticket</a>
<a href="#">Contact Us</a>
</div>
<div class="column">
<a class="footer_title">SHORT CUT</a>
<a href="">Our Services</a>
<a href="">Our Blog</a>
<a href="">Our Projects</a>
<a href="">About Us</a>
</div>
<div class="column">
<a class="footer_title">LATEST NEWS</a>
<a href="" title="Lorem ipsum dolor sit amet"><img src="https://source.unsplash.com/50x50/?green,trees"/></a>
<a href="" title="Lorem ipsum dolor sit amet"><img src="https://source.unsplash.com/50x50/?green,tree"/></a>
<a href="" title="Lorem ipsum dolor sit amet"><img src="https://source.unsplash.com/50x50/?green,plant"/></a>
<a href="" title="Lorem ipsum dolor sit amet"><img src="https://source.unsplash.com/50x50/?green,forest"/></a>
<a href="" title="Lorem ipsum dolor sit amet"><img src="https://source.unsplash.com/50x50/?green,afforestation"/></a>
</div>
<div class="column">
<a class="footer_title">GET IN TOUCH</a>
<a title="Address"><i class="fas fa-map-marker fa-lg"></i>007,Gandhipuram,Coimbatore</a>
<a href="emailto:" title="Email"><i class="fas fa-envelope fa-lg"></i> healthcare@yahoo.org</a>
<a href="tel:" title="Contact"><i class="fas fa-phone fa-lg"></i> +(2)-2433-09876</a>
</div>


<div class="sub-footer">
© CopyRights 2023 Healthcare || All rights reserved
</div>
</footer>
</div>
        </div>
    );  
}

export default Landing;


