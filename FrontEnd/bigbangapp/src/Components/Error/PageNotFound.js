import React, { useState } from "react";
import './PageNotFound.css'
import { Link } from "react-router-dom";

function PageNotFound(){
return (
    <div className="error-container">
        <div className="error-inner">
        <h1>401</h1>
        <p>You traveled abit to far my friend. I wish you well in your journey and remember,</p>
        <p class="quotething"> “If one dream should fall and break into a thousand pieces, never be afraid to pick one of those pieces up and begin again.” -<i>Flavia Weedn</i></p><br/>
        <div align="center">
        <Link to='/'><input type="button" class="button404" value="Return to Home" /></Link>
        </div>
        </div>
    </div>
  );
}

export default PageNotFound;
