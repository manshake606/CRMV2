//省份，城市 
var provinceDom = null; 
function InItDom(fname) { 
var tempdom; 
try { 
tempdom = new ActiveXObject("Microsoft.XMLDOM"); 
} catch (e) { 
try { 
tempdom = document.implementation.createDocument("", "", null); 
} 
catch (e) { 
alert(e.message); 
} 
} 
try { 
tempdom.async = false; 
tempdom.load(fname); 
//alert(tempdom.childNodes.length); 
} 
catch (e) { 
} 
return tempdom; 
} 
function InitProvince(provinceid) { 
var province = document.getElementById(provinceid); 
province.length = 0; 
if (provinceDom == null) 
provinceDom = InItDom("../config/Provinces.xml"); 
if (provinceDom != null) { 
var proNodes = provinceDom.childNodes[1].childNodes; 
//alert(proNodes.length); 
for (var i = 0; i < proNodes.length; i++) { 
var tempOption = document.createElement("option"); 
tempOption.value = proNodes[i].getAttribute("Name"); 
tempOption.text = proNodes[i].getAttribute("Name"); 
province.options.add(tempOption); 
} 
//alert(proNodes[1].getAttribute("Name")); 
} 
} 
function ResetCity(province, cityname) { 
var pname=province.value; 
var city = document.getElementById(cityname); 
city.length = 0; 
if (provinceDom == null) 
provinceDom = InItDom("../config/Provinces.xml"); 
if (provinceDom != null) { 
// alert(provinceDom.childNodes[1].childNodes.length); 
var root = provinceDom.selectNodes("Root")[0]; 
//Nodes = objXMLDoc.selectNodes("test/test1/test1"); 
// alert(root.childNodes.length); 
for (var i = 0; i < root.childNodes.length; i++) { 
if (root.childNodes[i].getAttribute("Name") == pname) { 
for (var j = 0; j < root.childNodes[i].childNodes.length; j++) { 
var tempOption = document.createElement("option"); 
tempOption.value = root.childNodes[i].childNodes[j].text; 
tempOption.text = root.childNodes[i].childNodes[j].text; 
city.options.add(tempOption); 

} 
break; 
} 
} 
} 
} 
