/******************************************
*	Constants
******************************************/


/******************************************
*	Globals
******************************************/
var btns = new Array();


function SetupButtons() {
	
	// Set up the handler for the canvas
	$("#" + CANVAS_NAME).click(function(e) {
		ClickEvent(e);
	});
	
	// Set up event handler for mouse move
	$("#" + CANVAS_NAME).mousemove(function(e) {
		MouseMoveEvent(e);
	});
	
	
	CreateButtons();

}

function CreateButtons() {
	console.log("Creating Buttons");

	// Create some buttons
	btns[0] = new Button("#0000FF", "", 10, 10,  50, 50);
	btns[1] = new Button("#0000FF", "", 10, 100,  50, 50);
	btns[2] = new Button("#0000FF", "", 10, 190,  50, 50);
	btns[3] = new Button("#0000FF", "", 10, 280, 50, 50);
	btns[4] = new Button("#0000FF", "", 10, 370, 50, 50);
	
	// Create a new image
	images[0] = new Image();
	
	// When the image has been downloaded create the button
	images[0].onload = function() {
		console.log("Creating Blue Button");
		btns.push(new Button("", images[0], 200, 400, 50, 50));
		Refresh();
	}
	
	// Set the image source
	console.log("Downloading B.png");
	images[0].src  = "images/B.png";
	
	Refresh();
	
	console.log("Exiting CreateButtons()");
}

function Refresh() {
	ClearCanvas();
	
	// Draw the buttons
	for (var i = 0; i< btns.length; i++) {
		
		// Check if the button has an image
		// if true draw it else draw the colour
		
		if (btns[i].image != "") {
			
			canvasContext.drawImage(btns[i].image, btns[i].x, btns[i].y, btns[i].w, btns[i].h);
			
		} else {
			// Set button colour
			canvasContext.fillStyle = btns[i].colour;
			// Draw button
			canvasContext.fillRect(btns[i].x, btns[i].y, btns[i].w, btns[i].h);
		}
		
		
		
		
	}
}

function ClearCanvas() {
	// Clear the canvas using default colour
	canvasContext.fillStyle = CANVAS_COLOUR;
	canvasContext.fillRect(0, 0, canvas.width,canvas.height);
}

function ClickEvent(e) {

	// Get the click coordinates
	var x = e.pageX - canvasOffset.left;
	var y = e.pageY - canvasOffset.top;
	
	// Loop through each button and check if the mouse had clicked inside it.
	for (var i = 0; i < btns.length; i++) {
	
		if ((x > btns[i].x && x < (btns[i].x + btns[i].w)) && (y > btns[i].y && y < (btns[i].y + btns[i].h))) {
			
			console.log("btn: " + i);
			
			// Call the function to handle the button action.
			ButtonClick(i);
		}
	}
}

function ButtonClick(id) {
	
	switch(id) {
		case 0:
			MoarButtons();
			Refresh();
			break;
		
	}
}

function MoarButtons() {

	for (var i = 0; i < 20; i++) {
		btns.push(new Button("", images[0], 25 * i, 70, 20, 20));
	}
	
	Refresh();
}


function MouseMoveEvent(e) {
	// Check if the mouse is inside any button.
	// If it is inside a button change the button state to hover.
	// When it leaves the button change the button state to normal.
	
}

function Button(colour, image, x, y, w, h) {
	this.colour=colour;
	this.image=image;
	this.x=x;
	this.y=y;
	this.w=w;
	this.h=h;
}


