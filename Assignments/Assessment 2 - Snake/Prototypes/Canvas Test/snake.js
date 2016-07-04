var toggle = false;
var pos = 0;

var canvas, ctx;

function Load() {
	
	canvas = document.getElementById("myCanvas");
	ctx = canvas.getContext("2d");
	ctx.fillStyle="#FF0000";
	ctx.fillRect(0,0,150,75);
	StartGame();
}

function StartGame() {
	FillGrid(true);
	window.setInterval("FillGrid(toggle);", 200);
}

function FillGrid(black) {
	//toggle = !toggle;
	var grid = [];
	
	var counter = 0;
	var offsetY = 0;
	var offsetX = 0;
	
	for (var rowX = 0; rowX < 50; rowX++) {
		for (var colY = 0; colY < 50; colY++) {
		
			if (black == false) {
				grid[counter] = new point(offsetX, offsetY, 2);
				//black = true;
			} else {
				grid[counter] = new point(offsetX, offsetY, 1);
				//black = false;
			}
			
			counter++;
			offsetY += 10;
		}
		offsetX += 10;
		offsetY = 0;
	}
	
	
	RenderGrid(grid);
	
	var snake = [];
	
	snake[0] = new point(50 + pos, 50, 3);
	pos += 10;
	RenderGrid(snake);
}

function point(x ,y ,value) {
this.x=x;
this.y=y;
this.value=value;
}

function RenderGrid(grid) {

	for (var i = 0; i < grid.length; i++) {
	
		if (grid[i].value == 1) {
			ctx.fillStyle="#000000";
		} else if (grid[i].value == 2) {
			ctx.fillStyle="#FF0000";
		} else if (grid[i].value == 3) {
			ctx.fillStyle="#33CC33";
		}
			
		ctx.fillRect(grid[i].x, grid[i].y, 10, 10)
	}
	
}

function myFunction() {
	FillGrid(!toggle);
}