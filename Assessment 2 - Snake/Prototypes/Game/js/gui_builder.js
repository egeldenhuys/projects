 var active = false;
 var btnIndex = 0;
 
 function InitGuiBuilder() {
	
	// Set up the hander for mouse click events
	$("#" + CANVAS_NAME).click(function(e) {
		tmpClickEvent(e);
	});
	
	// Set up the handler for mouse move events
	$("#" + CANVAS_NAME).mousemove(function(e) {
		tmpMoveEvent(e);
	});
	
 }
 
 function tmpClickEvent(e) {
	 active = false;
	
}

function tmpMoveEvent(e) {
	
	if (active == true) {
		 // Get the click coordinates
		var x = e.pageX - canvasOffset.left;
		var y = e.pageY - canvasOffset.top;
		
		// Draw button
		btns[btnIndex].x = x;
		btns[btnIndex].y = y;
		
		// Background
		canvasContext.drawImage(GetImage("images/SnakeGame.png"), 0, 0);
		
		//Text
		canvasContext.fillStyle = "#00FF00";
		canvasContext.font = "30px Bauhaus";
		canvasContext.fillText("Score: XXX", x, y);
		
	
		//DrawButtons();
		
		$("#gui").text(x + ", " + y);
		
	}
	
}
