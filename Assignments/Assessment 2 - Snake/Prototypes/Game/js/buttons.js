
/* 
Features:
	* When a button is clicked the corresponding function is called
	* When the mouse enters the button a different image is displayed
		to indicate the game is responding to user actions
	* When the mouse leaves a button its default image is displayed 
*/


/******************************************
*	Globals
******************************************/
var btns = new Array();	// This array will store the buttons active on the current
						// screen
						
var lastBtnIndex = 9001;
var lastBtnId;

function InitButtons() {
	
	// Set up the hander for mouse click events
	$("#" + CANVAS_NAME).click(function(e) {
		ClickEvent(e);
	});
	
	// Set up the handler for mouse move events
	$("#" + CANVAS_NAME).mousemove(function(e) {
		MoveEvent(e);
	});
	

}

// Button object
function Button(id, defaultImage, hoverImage, x, y) {
	this.id=id;	// The id for the button, each button in the game needs a unique id
	this.defaultImage=defaultImage;
	this.hoverImage=hoverImage;
	this.x=x;
	this.y=y;
	this.state=0; // 0 : draw default image. 1 : hover
	this.w = defaultImage.width; // Width
	this.h = defaultImage.height; // Heigth
}

function ClickEvent(e) {
	/*
		Check if the mouse is inside a button
		if it is call the corresponding function
	*/
	
	// Get the click coordinates
	var x = e.pageX - canvasOffset.left;
	var y = e.pageY - canvasOffset.top;
	
	// Loop through each button and check if the mouse is inside it
	for (var i = 0; i < btns.length; i++) {
	
		if ((x > btns[i].x && x < (btns[i].x + btns[i].w)) && (y > btns[i].y && y < (btns[i].y + btns[i].h))) {
			
			console.log("btn: " + btns[i].id);
			
			// Call the function to handle the button action.
			ButtonEvent(btns[i].id);
		}
	}
	
}

function CreateButton(id, defaultImage, hoverImage, x, y) {
	// Create the button object
	
	var tmpBtn = new Button(id, defaultImage, hoverImage, x, y);
	// Add it to the array
	btns.push(tmpBtn);
}

function ButtonEvent(id) {
	
	switch(id) {
	
	// Start Game
	case 0:
		SnakeGame(false);
		break;
		
		// Pause
	case 1:
		running = !running;
		break;
		
		// Main Menu
	case 2:
		SnakeDeath();
		MainMenu();
		break;
	
		// Continue
	case 3:
		MainMenu();
		break;
	}
	
	lastBtnIndex = 9001;
	
}

function DrawButtons() {

	// Draw all buttons
	for (var i = 0; i < btns.length; i++) {
		
		// Draw the button in its correct state
		if (btns[i].state == 0) {
			canvasContext.drawImage(btns[i].defaultImage, btns[i].x, btns[i].y);
		} else {
			canvasContext.drawImage(btns[i].hoverImage, btns[i].x, btns[i].y);
		}
		
	}
}

function MoveEvent(e) {
	
	/*
		If the mouse is inside a button change its image to hover and redraw once
		
		if the mouse is no longer in a button change the last button image
		to default and redraw once
	*/
	
	// Get the click coordinates
	var x = e.pageX - canvasOffset.left;
	var y = e.pageY - canvasOffset.top;
	
	var touched = false;
	var id;
	var index;
	
	// Loop through each button and check if the mouse is inside it
	for (var i = 0; i < btns.length; i++) {
		
		if ((x > btns[i].x && x < (btns[i].x + btns[i].w)) && (y > btns[i].y && y < (btns[i].y + btns[i].h))) {
			
			touched = true;
			id = btns[i].id;
			index = i;
		} 
	}
	

	if (touched == true) {
		
		// If it is not the same button change its state to hover
		if (lastBtnIndex != index) {
			console.log("Enter button: " + id)
			
			// Set hover state
			btns[index].state = 1;
			
			lastBtnIndex = index;
			lastBtnId = id;
			
			DrawButtons();
		}
		
	} else {
	
		if (lastBtnIndex != 9001) {
			console.log("Leave button: " + lastBtnId);
			
			// Set default state
			btns[lastBtnIndex].state = 0;
			lastBtnIndex = 9001;
			
			DrawButtons();
		}
	}
}



