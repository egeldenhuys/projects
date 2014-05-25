var CANVAS_NAME = "myCanvas";
var CANVAS_WIDTH = 1920;
var CANVAS_HEIGHT = 1080;
var RATE = 0;
var res = 20;

var a = 0;
var r = 255;
var g = 255;
var b = 255;

var colour;
// Format Colour
	colour = "#";
	
	if (r < 15)
		colour = colour + "0";
	
	colour = colour + r.toString(16);
		
	if (g < 15)
		colour = colour + "0";

	colour = colour + g.toString(16);
		
	if (b < 15)
		colour = colour + "0";

	colour = colour + b.toString(16);
		
	console.log(r, g, b, colour);
	

// Get canvas object
var canvas = document.getElementById(CANVAS_NAME);
var canvasContext = canvas.getContext("2d");

canvas.width = CANVAS_WIDTH;
canvas.height = CANVAS_HEIGHT;

canvasContext.fillStyle="#000000";
canvasContext.fillRect(0, 0, CANVAS_WIDTH, CANVAS_HEIGHT); 

canvasContext.strokeStyle=colour;

var power = 0;

Draw();

function DrawGrid() {
	canvasContext.strokeStyle="#FF0000";
	
	canvasContext.beginPath();
	
	canvasContext.moveTo(CANVAS_WIDTH/2, CANVAS_HEIGHT /2);
	canvasContext.lineTo(CANVAS_WIDTH/2, CANVAS_HEIGHT);
	canvasContext.lineTo(CANVAS_WIDTH/2, 0);
	
	canvasContext.moveTo(CANVAS_WIDTH/2, CANVAS_HEIGHT /2);
	canvasContext.lineTo(0, CANVAS_HEIGHT/2);
	canvasContext.lineTo(CANVAS_WIDTH, CANVAS_HEIGHT/2);
	
	canvasContext.stroke(); 
}

function Draw() {
//canvasContext.fillStyle="#000000";
//canvasContext.fillRect(0,0,CANVAS_WIDTH,CANVAS_HEIGHT);

var x = 0;
var y = 0;

	canvasContext.strokeStyle=colour;
	IncrementColour();
	
	canvasContext.beginPath();
//canvasContext.moveTo(CANVAS_WIDTH/2, CANVAS_HEIGHT /2);
	
	for (var i = - CANVAS_WIDTH / res; i < CANVAS_WIDTH / res; i = i + 1 / res) {
	
		x = i;
		y = Math.sin(x)*Math.cos(power);
		
		canvasContext.fillStyle=colour;
		//canvasContext.fillRect(CANVAS_WIDTH/2 + x *res, CANVAS_HEIGHT /2 - y*res, 5, 5)
		canvasContext.lineTo(CANVAS_WIDTH/2 + x *res, CANVAS_HEIGHT /2 - y*res);

	}
	
	canvasContext.stroke(); 

power = power + (1 / res);
DrawGrid();
window.setTimeout("Draw()", RATE);

}

function IncrementColour() {
	var c = 10;
	
	
	var rnd = Math.floor((Math.random()*3)+1);
	
	switch (rnd) 
	{
		case 1:
			r = r + c;
			break;
		case 2:
			g = g + c;
			break;
		case 3: 
			b = b + c;
			break;
	}
	

	//b = b + c;
	
	if (b > 255) {
		b = 0;
		g = g + c;
	}
	
	if (g > 255) {
		g = 0;
		r = r + c;
	}
	
	if (r > 255) {
		r = 0;
	}


	// Format Colour
	colour = "#";
	
	if (r < 15)
		colour = colour + "0";
	
	colour = colour + r.toString(16);
		
	if (g < 15)
		colour = colour + "0";

	colour = colour + g.toString(16);
		
	if (b < 15)
		colour = colour + "0";

	colour = colour + b.toString(16);
		
	console.log(r, g, b, colour);
}
