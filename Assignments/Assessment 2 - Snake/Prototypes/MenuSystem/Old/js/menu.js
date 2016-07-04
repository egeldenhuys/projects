var canvas,canvasContext;

function Init() {
	SetupCanvas();
	ScreenMain();
}

	  
function SetupCanvas() {

	//Get object and setup
	canvas = document.getElementById("canvas");
	canvasContext=canvas.getContext("2d");
	
	canvas.width = 500;
	canvas.height = 500;

	canvasContext.fillStyle = "#009933";
	canvasContext.fillRect(0,0,canvas.width,canvas.height);
	
}

function ScreenMain() {
	console.log("Writing Text");
	canvasContext.fillStyle = "#FF0000";
	canvasContext.font = "20px Georgia";
	// canvasContext.fillText(Text, xOffset, yOffset);
	// The y offset is measured from the bottom of the text."
	canvasContext.fillText("Snake", 0, 20);
}

function writeMessage(canvas, message) {
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.font = '18pt Calibri';
        context.fillStyle = 'black';
        context.fillText(message, 10, 25);
      }
	  
      function getMousePos(canvas, evt) {
        var rect = canvas.getBoundingClientRect();
        return {
          x: evt.clientX - rect.left,
          y: evt.clientY - rect.top
        };
      }
	  
/*
function LoadImage() {

	var img = new Image;
	
	img.onload = function() {
		canvasContext.drawImage(img, 0, 0);
	}
	
	img.src = "http://www.w3schools.com/tags/img_the_scream.jpg";
	
}
*/