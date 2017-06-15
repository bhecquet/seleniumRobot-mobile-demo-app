﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;

namespace TestRoom
{
    public class WebViewHtmlContent : ContentPage
    {
        String content;

        public WebViewHtmlContent()
        {
            content = getHtmlContent();
        }

        public static String getHtmlContent()
        {
            return @"<!DOCTYPE html>
<html>
<head>
</head>
 
<body>
	<h3>Test clicking a moving element</h3>
	<button id=""button"">Start Animation</button>
	<div style=""background:#98bf21;height:20px;width:10px;position:absolute;"" id=""carre""></div>
                 


	<h3>Test clicking an element</h3>
	<button id=""button2"" name=""resetButton"">reset</button>
	<div style=""background:red;height:20px;width:20px;display: inline-block;"" id=""carre2""></div>
	<div style=""display: inline-block;""><input id=""text2"" name=""textField""/></div>
	<input type=""radio"" id=""radioClick"" name=""radioClick"">
	<input type=""checkbox"" id=""checkboxClick"" name=""checkboxClick"">
	<input type=""image"" id=""image"" name=""image"" src=""googleSearch.png"" >
                  


    <h3>Test select</h3>
	<select id=""select"" name=""select"" onChange=""selector1()"">
		<option value=""opt1"">option1</option>
		<option value=""opt2"">option2</option>
		<option value=""opt3"">option numero 3</option>
	</select>
	<input id=""textSelectedId""/>
	<input id=""textSelectedValue""/>
	<input id=""textSelectedText""/>


    <script>
        document.getElementById(""carre"").onclick = function() { alert(""coucou""); };
        document.getElementById(""button"").onclick = function(){
            var elem = document.getElementById(""carre"");   
            var pos = 0;
            var id = setInterval(frame, 5);
            function frame(){
                if (pos == 250) { clearInterval(id); }
                else            { pos++;    elem.style.left = pos + 'px'; }
            }
        };

        document.getElementById(""button2"").onclick = function(){ 
            addText(""text2"", """");
            resetState();
        }
            
        document.getElementById(""carre2"").onclick = function(){   addText(""text2"", ""coucou""); };
        document.getElementById(""image"").onclick = function(){    addText(""text2"", ""image""); };

        function selector1() { 
            select = document.getElementById(""select"");
            choix = select.selectedIndex;
            val = select.options[choix].value;
            text = select.options[choix].text;

            addText(""textSelectedId"", choix);
            addText(""textSelectedValue"", val);
            addText(""textSelectedText"", text);
        };

        function addText(id, text) {
	        document.getElementById(id).value = text;
        }

        function resetState() {
	        document.getElementById(""checkboxClick"").checked = false;
	        document.getElementById(""radioClick"").checked = false;
        }


    </script>

                        
</body>
</html>";
        }
    }
}
