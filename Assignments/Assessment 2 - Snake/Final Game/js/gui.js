// If refresh is true the gui will only be 
// redrawn instead of new objects being created

function MainMenu() {
	ResetGui();
	
	// Background
	canvasContext.drawImage(GetImage("images/MainMenu.png"), 0, 0);
	
	// Buttons
	
	// Start Button
	CreateButton(0, GetImage("images/btnStart0.png"), GetImage("images/btnStart1.png"), 146, 227);
	
	DrawButtons();
	
}

function SnakeGame() {
	ResetGui();
	
	// Background
	canvasContext.drawImage(GetImage("images/SnakeGame.png"), 0, 0);
	
	// Buttons
	CreateButton(1, GetImage("images/btnPause0.png"), GetImage("images/btnPause1.png"), 350, 509);
	CreateButton(2, GetImage("images/btnMenu0.png"), GetImage("images/btnMenu1.png"), 8, 509);
	
	StartGame();
	
	DrawButtons();
}

function DeathScreen() {
	console.log("Death Screen");
	
	// Save the previous screen to show the player how they died
	var prev = canvasContext.getImageData(0, 0, 500, 500);
	
	ResetGui();
	
	// Background
	canvasContext.drawImage(GetImage("images/SnakeGame.png"), 0, 0);
	
	// Draw the previous image over the background
	canvasContext.putImageData(prev, 0, 0);
	
	// Buttons
	CreateButton(3, GetImage("images/btnContinue0.png"), GetImage("images/btnContinue1.png"), 142, 256);
	
	// Text
	canvasContext.fillStyle = "#00CC00";
	canvasContext.font = "30px Bauhaus";
	canvasContext.fillText("Score: " + score, 191, 225);
	
	
	
	DrawButtons();
}

function ResetGui() {
	btns.length = 0;
	ClearCanvas();
	
}