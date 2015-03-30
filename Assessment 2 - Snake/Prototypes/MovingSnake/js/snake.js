/******************************************
*	Constants
******************************************/
const GRID_SIZE = 32;		//Size of the squares
const DEBUG_MODE = false;	//Should we print debug messages and grids?
const GAME_SPEED = 10;		//The milliseconds between updates
const SNAKE_COLOUR = "#FF0000";	//Default snake colour
const GRID_COLOUR = "#000000"; 	//Default grid colour
const FOOD_COLOUR = "#0000FF";	//Default food colour

/******************************************
*	Globals
******************************************/
var width = window.innerWidth;
var height = window.innerHeight;

//Change these to whatever you want to set the width and height of the board
var gridPerWidth = 10;//Math.round(width / GRID_SIZE);
var gridPerHeight = 10;//Math.round(height / GRID_SIZE);

var lastKey = 0;			//Last key pressed by the user

var canvas;					//Reference to the canvas object (set in SetupCanvas)
var canvasContext;			//Reference to the canvas context (set in SetupCanvas)

var running = true;			//Should the game keep running (for pausing)
	
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

/******************************************
*	Handler functions
******************************************/
$(window).load(function() {
	Init();

	
});

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

$(window).keydown(function(event) {
	lastKey = event.keyCode;
});

/******************************************
*	Canvas functions
******************************************/
function SetupCanvas() {

	//Get object and setup
	canvas = document.getElementById("canvas");
	canvas.width = GRID_SIZE * gridPerWidth;
	canvas.height = GRID_SIZE * gridPerHeight;
	
	canvasContext=canvas.getContext("2d");
	canvasContext.fillStyle = GRID_COLOUR;
	canvasContext.fillRect(0,0,canvas.width,canvas.height);
	
}

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
		
		for (var i = 0; i < snake.length; i++) {
			DrawSquare(snake.body[i].x,snake.body[i].y,SNAKE_COLOUR);
		}
		
		snake.frameCount = 0;
		//if(DEBUG_MODE) DrawDebugGrid();		//NOTE: Disabled for performance
		
	}

}

function GrowSnake() {
	
	//Increase the size of the snake by one
	snake.body[snake.length] = new Object();
	snake.body[snake.length].x = snake.body[snake.length-1].x;
	snake.body[snake.length].y = snake.body[snake.length-1].y;
	snake.pause = true;
	snake.length += 1;
	
}

function DrawSquare(x,y,color) {
	
	canvasContext.fillStyle=color;
	canvasContext.fillRect(GRID_SIZE*x,GRID_SIZE*y,GRID_SIZE,GRID_SIZE);
	
}

/******************************************
*	Main functions
******************************************/
function Init() {
	
	//Do the main functionality
	SetupCanvas();
	SetupSnake();
	if(DEBUG_MODE) DrawDebugGrid();
	var mainLoop = setInterval(function(){Main()},GAME_SPEED);
	
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
		console.log(lastKey);
		
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