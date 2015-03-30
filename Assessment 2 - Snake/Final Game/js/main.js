/******************************************
*	Main
*	All global variables required by multiple 
*	scripts are declared in this script.
*	
******************************************/

/******************************************
*	Constants
******************************************/
var CANVAS_NAME = "gameScreen";
var CANVAS_WIDTH = 500;
var CANVAS_HEIGHT = 550;

/******************************************
*	Globals
******************************************/
var canvas;					// Reference to the canvas object (set in SetupCanvas)
var canvasContext;			// Reference to the canvas context (set in SetupCanvas)
var images = new Array();	// Array for storing images used by the game
var imagesLoaded = 0;	// The amount of iamges that has been succesfully loaded
var totalImages = 0;	// How many images there are to load
var rootUrl;	// url used to append image source to

// Initialize scripts when everything has been loaded
$(window).load(function() {
	Init();
	
});

function Init() {
	// Example: file:///C:/Users/Evert/Dropbox/SDD/Assignments/Snake/Prototypes/Game/index.html
	var tmpString = window.location.href;
	
	// Remove index.html from the string to get the root
	rootUrl = tmpString.slice(0, tmpString.length - 10);
	
	console.log("Starting game.");
	
	SetupCanvas();
	LoadImages();

}

function ImageLoaded(img) {
	imagesLoaded++;
	
	// Add the newly loaded image to the array
	images.push(img);
	
	// If all images has been loaded continue initializing the rest of the game
	if (imagesLoaded == totalImages) {
		console.log("All images loaded.");
		InitButtons();
		MainMenu(false);
		InitGuiBuilder();
	}
	
}

function SetupCanvas() {
	console.log("Setting up canvas");
	
	//Get canvas object and set sizes
	canvas = document.getElementById(CANVAS_NAME);
	canvas.width = CANVAS_WIDTH;
	canvas.height = CANVAS_HEIGHT;
	
	canvasContext=canvas.getContext("2d");
	
	// Get the canvas offset using jquery
	canvasOffset = $("#" + CANVAS_NAME).offset();
}

function LoadImages() {
	console.log("Loading Images...");
	
	// List of images
	
	// Backgrounds
	AddImage("images/MainMenu.png");
	AddImage("images/SnakeGame.png");
	AddImage("images/DeathScreen.png");
	
	// Buttons
	AddImage("images/btnStart0.png");
	AddImage("images/btnStart1.png");
	
	AddImage("images/btnPause0.png");
	AddImage("images/btnPause1.png");
	
	AddImage("images/btnContinue0.png");
	AddImage("images/btnContinue1.png");
	
	AddImage("images/btnMenu0.png");
	AddImage("images/btnMenu1.png");
	
}

function AddImage(src) {
	// Should only be called before other scripts are initialized.
	
	// Increase the number of images there are since we are adding a new one
	totalImages++;
	
	// Create the new image object
	var img = new Image;
	
	// When it is loaded pass it to the function to add it to the array
	img.onload = function() {
		ImageLoaded(img);
	}
	
	// set the image source
	img.src = src;
}

function GetImage(srcToFind) {	 
	
	// Loop through each image and check if its source matches the given source
	for (var i = 0; i < totalImages; i++) {
		if (images[i].src == (rootUrl + srcToFind)) {
			// Return the image
			return images[i]
		}
	}
}

function ClearCanvas() {
	canvasContext.clearRect(0, 0, canvas.width, canvas.height);
}

