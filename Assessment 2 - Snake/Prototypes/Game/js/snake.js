/******************************************
*	Constants
******************************************/
var GRID_SIZE = 10;		//Size of the squares
var DEBUG_MODE = false;	//Should we print debug messages and grids?
var GAME_SPEED = 10;		//The milliseconds between updates
var SNAKE_COLOUR = "#FF0000";	//Default snake colour
var GRID_COLOUR = "#000000"; 	//Default grid colour
var FOOD_COLOUR = "#0000FF";	//Default food colour


/******************************************
*	Globals
******************************************/
var width = window.innerWidth;
var height = window.innerHeight;

//Change these to whatever you want to set the width and height of the board
var gridPerWidth = 50;//Math.round(width / GRID_SIZE);
var gridPerHeight = 50;//Math.round(height / GRID_SIZE);

var lastKey = 0;			//Last key pressed by the user

var running = true;			//Should the game keep running (for pausing)

var snake = new Object();
snake.body = new Array();
snake.body[0] = new Object();
snake.body[1] = new Object();
snake.body[2] = new Object();
snake.body[0].x = 0;		//Front of snake x-axis
snake.body[0].y = 0;		//Front of snake y-axis
snake.body[1].x = 0;		//Middle of snake x-axis
snake.body[1].y = 0;		//Middle of snake y-axis
snake.body[2].x = 0;		//End of snake x-axis
snake.body[2].y = 0;		//End of snake y-axis
snake.length = 3;			//How long is the snake (do we need this?)
snake.speed = 10;			//How many frames to take to move (higher = slower)
snake.frameCount = 0;		//How many frames have passed since the last move?
snake.dir = 0;				//0 = Up, 1 = Down, 2 = Left, 3 = Right
snake.pause = false;		//This pauses the snake's last piece for one move (used for growing)

var food = new Object();
var score = 0;
var mainLoop;
var alive = false;

/******************************************
*	Handler functions
******************************************/

/*
$(window).resize(function() {
	
	//Reset globals
	width = $(window).width();
	height = $(window).height();
	gridPerWidth = Math.round(width / GRID_SIZE);
	gridPerHeight = Math.round(height / GRID_SIZE);
	
	//Resize canvas
	canvas.width = GRID_SIZE * gridPerWidth;
	canvas.height = GRID_SIZE * gridPerHeight;
	
	if(DEBUG_MODE) DrawDebugGrid();
	
});	
*/

$(document).keydown(function(event) {
	lastKey = event.keyCode;
});

/******************************************
*	Canvas functions
******************************************/

function DrawDebugGrid() {

	//Draw the y lines
	for(var i = 0; i <= gridPerWidth; i++) {
	
		canvasContext.moveTo(i * GRID_SIZE, 0);
		canvasContext.lineTo(i * GRID_SIZE, GRID_SIZE * gridPerHeight);
		canvasContext.stroke();
	
	}
	
	//Draw the x lines
	for(var i = 0; i <= gridPerHeight; i++) {
	
		canvasContext.moveTo(0, i * GRID_SIZE);
		canvasContext.lineTo(GRID_SIZE * gridPerWidth, i * GRID_SIZE);
		canvasContext.stroke();
	
	}

}

/******************************************
*	Snake functions
******************************************/
function SetupSnake() {
	
	//Setup defaults for the snake object
	snake.body[0].x = Math.round(gridPerWidth/2);
	snake.body[0].y = Math.round(gridPerHeight/2);
	snake.body[1].x = snake.body[0].x-1;
	snake.body[1].y = snake.body[0].y;
	snake.body[2].x = snake.body[0].x-2;
	snake.body[2].y = snake.body[0].y;

}

function MovePiece(dir) {
	
	//Where do we start
	var start = snake.length-1;
	if(snake.pause) {
		start -= 1;
		snake.pause = false;
	}
	
	//Shuffle through the parts
	for(var i = start; i >= 1; --i) {
	
		//I tried object swap but javascript came up with crazy values then (such as -65 etc)
		snake.body[i].x = snake.body[i-1].x;
		snake.body[i].y = snake.body[i-1].y;
		
	}

	switch(dir) {
		//Up
		case 0:
			snake.body[0].y -= 1;
			if(snake.body[0].y < 0) snake.body[0].y = gridPerHeight-1;
			break;
		//Down
		case 1:
			snake.body[0].y += 1;
			if(snake.body[0].y >= gridPerHeight) snake.body[0].y = 0;
			break;
		//Left
		case 2:
			snake.body[0].x -= 1;
			if(snake.body[0].x < 0) snake.body[0].x = gridPerWidth-1;
			break;
		//Right
		case 3:
			snake.body[0].x += 1;
			if(snake.body[0].x >= gridPerWidth) snake.body[0].x = 0;
			break;
	
	}

}

function MoveSnake() {

	//Check the frame we've on
	if(snake.frameCount < snake.speed) {
		snake.frameCount += 1;
	}
	else {
	
		//Check the last pressed key
		CheckInput();

		//Automated move function based on dir
		DrawSquare(snake.body[snake.length-1].x,snake.body[snake.length-1].y,GRID_COLOUR);
		MovePiece(snake.dir);
		
		// Check if the snake as hit anything
		CheckCollision();
		
		if (alive == true) {
			for (var i = 0; i < snake.length; i++) {
				DrawSquare(snake.body[i].x,snake.body[i].y,SNAKE_COLOUR);
			}
		}
		
		snake.frameCount = 0;
		//if(DEBUG_MODE) DrawDebugGrid();		//NOTE: Disabled for performance
		
	}
	
	if (alive == true) {
		DrawSquare(food.x, food.y, FOOD_COLOUR);
	}
	
}

function CheckCollision() {
	
	// Snake body
	
	//Loop through all the parts and see if the head hits any
	for (var i = 1; i < snake.length-1; i++) {
		if((snake.body[0].x == snake.body[i].x) && (snake.body[0].y == snake.body[i].y)) {
			SnakeDeath();
		}
	}
	
	// Food
	if ((snake.body[0].x == food.x) && (snake.body[0].y == food.y)) {
			
			score++;
			
			DisplayScore();
		
			for (var i = 0; i < 5; i++) {
				GrowSnake();
			}
			
			GenerateFood();
		}
		
}

function GenerateFood() {
	var clear = false;
	var x;
	var y;
	
	// Make sure not to place food on the snake
	while (clear == false) {
		// Food coordinates
		x = Math.floor((Math.random()*50));
		y = Math.floor((Math.random()*50));
		
		// set clear to true, when food is on the snake clear will be set to false
		// if food is not on the snake the loop will exit and create the food object.
		clear = true;
		
		//Loop through all the parts and see if food will be on the snake
		for (var i = 1; i < snake.length-1; i++) {
		
			// Check if the coordinates are on any part of the snake
			if((x == snake.body[i].x) && (y == snake.body[i].y)) {
				console.log("Placed food inside the snake, trying again");
				clear = false;
			}
			
		}
	}
	
	console.log("Placing food at: " + x + ", " + y);
	
	// Set the coordinates of the food and draw it
	food.x = x;
	food.y = y;
	
	DrawSquare(food.x, food.y, FOOD_COLOUR);
	
}
function GrowSnake() {
	
	//Increase the size of the snake by one
	snake.body[snake.length] = new Object();
	snake.body[snake.length].x = snake.body[snake.length-1].x;
	snake.body[snake.length].y = snake.body[snake.length-1].y;
	snake.pause = true;
	snake.length += 1;
	
}

function DisplayScore() {
	
	// Refresh screen (clear old score)
	canvasContext.drawImage(GetImage("images/SnakeGame.png"), 0, 0);
	DrawButtons();
	
	// Display new score
	canvasContext.fillStyle = "#00FF00";
	canvasContext.font = "30px Bauhaus";
	canvasContext.fillText(score, 224, 533);
}


function SnakeDeath() {

	Reset();
	DeathScreen();
	
	//ClearCanvas();
	//MainMenu(false);
}

function Reset() {
	clearInterval(mainLoop);
	alive = false;
	
	snake = new Object();
	snake.body = new Array();
	snake.body[0] = new Object();
	snake.body[1] = new Object();
	snake.body[2] = new Object();
	snake.body[0].x = 0;		//Front of snake x-axis
	snake.body[0].y = 0;		//Front of snake y-axis
	snake.body[1].x = 0;		//Middle of snake x-axis
	snake.body[1].y = 0;		//Middle of snake y-axis
	snake.body[2].x = 0;		//End of snake x-axis
	snake.body[2].y = 0;		//End of snake y-axis
	snake.length = 3;			//How long is the snake (do we need this?)
	snake.speed = 10;			//How many frames to take to move (higher = slower)
	snake.frameCount = 0;		//How many frames have passed since the last move?
	snake.dir = 0;				//0 = Up, 1 = Down, 2 = Left, 3 = Right
	snake.pause = false;		//This pauses the snake's last piece for one move (used for growing)

}

function DrawSquare(x,y,color) {

	if (alive == false) {
		console.log("Sqaure: " + x + ", " + y + ", " + color);
		
	}
	
	canvasContext.fillStyle=color;
	canvasContext.fillRect(GRID_SIZE*x,GRID_SIZE*y,GRID_SIZE,GRID_SIZE);
	
}

/******************************************
*	Main functions
******************************************/
function StartGame() {
	score = 0;
	
	DisplayScore();
	lastKey = 0;
	alive = true;
	
	running = true;
	GenerateFood();
	SetupSnake();
	
	if(DEBUG_MODE) DrawDebugGrid();
	mainLoop = setInterval(function(){Main()},GAME_SPEED);
	
}

function Main() {

	//Repeat bro, lots
	if(running) {
	
		MoveSnake();
	
	}

}

function CheckInput() {

	//TODO: Add different keys for pause and others
	if(DEBUG_MODE) {
		//Times (*) Key
		if(lastKey == 106) {
			GrowSnake();
			lastKey = 0;
		}
		//Plus (+) Key
		if(lastKey == 107) {
			snake.speed -= 1;
			lastKey = 0;
		}
		//Minus (-) Key
		if(lastKey == 109) {
			snake.speed += 1;
			lastKey = 0;
		}
		//console.log(lastKey);
		
	}
	//Used to control the snake's dir
	switch(lastKey) {
		//Up and W
		case 38:
		case 87:
			if(snake.dir != 1) snake.dir = 0;
			break;
		//Down and S
		case 40:
		case 83:
			if(snake.dir != 0) snake.dir = 1;
			break;
		//Left and A
		case 37:
		case 65:
			if(snake.dir != 3) snake.dir = 2;
			break;
		//Right and D
		case 39:
		case 68:
			if(snake.dir != 2) snake.dir = 3;
			break;
		
	}

}