/******************************************
*	Constants
******************************************/


/******************************************
*	Globals
******************************************/
var btnState = "B";
var btnB;
var btnG;
var btnBH;


function SetupButtons() {
	
	// Set up the handler for the canvas
	$("#" + CANVAS_NAME).click(function(e) {
		ClickHandler(e);
	});
	
	// Set up event handler for mouse move
	$("#" + CANVAS_NAME).mousemove(function(e) {
		MouseMoveEvent(e);
	});
	
	var btns = new Array();
	
	btns[0] = new Button(0, 1, 1, 2, 2);
	
	// Load Buttons
	btnG = new Image();
	btnG.src = "images/R.png";
	
	btnBH = new Image();
	btnBH.src = "images/BH.png";
	
	btnB = new Image();
	
	// Draw button when loaded.
	btnB.onload = function() {
		DrawImage(btnB, 200, 200, 100, 100)
	}
	
	btnB.src = "images/B.png";

}

function ToggleState() {
	
	if (btnState == "B") {
		btnState = "G";
		DrawImage(btnG, 200, 200, 100, 100);
		
	} else {
		btnState = "B";
		DrawImage(btnB, 200, 200, 100, 100);
	}
	
}
	
function ClickHandler(e) {
	// Print the coordinates to the screen
	
	//clickPos = "Clicked: " + (e.pageX - canvasOffset.left) + ", " + (e.pageY - canvasOffset.top);
	
	var x = e.pageX - canvasOffset.left;
	var y = e.pageY - canvasOffset.top;
	
	if ((x > 200 && x < 300) && (y > 200 && y < 300)) {
		ToggleState();
	}
	
}

function MouseMoveEvent(e) {
	
	//movePos = "Moved: " + (e.pageX - canvasOffset.left) + ", " + (e.pageY - canvasOffset.top);
	
	var x = e.pageX - canvasOffset.left;
	var y = e.pageY - canvasOffset.top;
	
	if ((x > 200 && x < 300) && (y > 200 && y < 300)) {
		DrawImage(btnBH, 200, 200, 100, 100);
	} else {
		DrawImage(btnB, 200, 200, 100, 100);
	}
	
}

function DrawImage(img, x, y, w, h) {
	canvasContext.drawImage(img, x, y, w, h);
}

function Button(image, x, y, w, h) {
	this.image=image;
	this.x=x;
	this.y=y;
	this.w=w;
	this.h=h;
}


