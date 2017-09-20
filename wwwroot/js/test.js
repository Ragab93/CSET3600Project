/**
 * Created by MattDiederick on 9/19/17.
 */
// points
function Point(x,y)
{
    this.leftPercent =x;
    this.topPercent = y;
}
var points = [
    new Point(10,50),
    new Point(80,50),
    new Point(45,20),
    new Point(45,80),
    new Point(10,20),
    new Point(10,80),
    new Point(80,20),
    new Point(80,80),
    new Point(27,20),
    new Point(27,80),
    new Point(62,20),
    new Point(62,80)

];
var addElement = (function(){
    var index =0;

    function addImg(point){
        this.point = point;
        var newEl = document.createElement("img");
        newEl.setAttribute("src", "./images/computer.jpg");
        newEl.setAttribute("width", "50px");
        newEl.style.position = "absolute";
        newEl.style.left = this.point.leftPercent + '%';
        newEl.style.top = this.point.topPercent + '%';

        //newEl.appendChild(content);

        var curr = document.getElementById("box");
        curr.appendChild(newEl);
        index = index + 1;
    }
    return {
        add : function(){
            addImg(points[index]);
        }
    }
})();



function ToggleVisibility(){
   var div = document.getElementById("addHost");
   if(div.style.display !== 'none')
   {
       div.style.display = 'none';
   }
   else{
       div.style.display = 'block';
   }
}

function Host(name, eth0) {
    this.name = name;
    this.eth0 - eth0;
}

function postHost() {
    var name = document.getElementById("name").value;
    var eth0 = document.getElementById("eth0").value;

    //console.log(name);
   // console.log(eth0);
    var host = new Host(name, eth0);
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/create/addhost', true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.send(JSON.stringify(name));

}