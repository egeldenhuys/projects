try
{
var canvas, ctx;
var direction = 1;
var snakeHead = new block(0,0,10,10);
var txt="";
}
catch(err)
   {
   txt="There was an error on this page.\n\n";
   txt+="Error description: " + err.message + "\n\n";
   txt+="Click OK to continue.\n\n";
   alert(txt);
   }
 
function Load() {
	try
	{
	// Set up canvas variables
	canvas = document.getElementById("SnakeCanvas");
	ctx = canvas.getContext("2d");
	
	setInterval("MoveBlock()", 1000);
	}
	catch(err)
   {
   txt="There was an error on this page.\n\n";
   txt+="Error description: " + err.message + "\n\n";
   txt+="Click OK to continue.\n\n";
   alert(txt);
   }

}

function MoveBlock() {
	try
	{
	switch(direction)
	{
	case 1:
		snakeHead.x -= 10;
		break;
	case 2:
		snakeHead.y += 10;
		break;
	case 3:
		snakeHead.x += 10;
		break;
	case 4:
		snakeHead.y -= 10;
		break;
	}
	
	DrawBlock();
	}
	catch(err)
   {
   txt="There was an error on this page.\n\n";
   txt+="Error description: " + err.message + "\n\n";
   txt+="Click OK to continue.\n\n";
   alert(txt);
   }
 }


function DrawBlock() {
	try
	{
	ctx.fillStyle="#FF0000";
	ctx.fillRect(snakeHead.x ,snakeHead.y ,snakeHead.w ,snakeHead.h);
	}
	catch(err)
   {
   txt="There was an error on this page.\n\n";
   txt+="Error description: " + err.message + "\n\n";
   txt+="Click OK to continue.\n\n";
   alert(txt);
   }
 
}

function block(x ,y ,w ,h)
 {
 try
 {
 this.x=x;
 this.y=y;
 this.w=w;
 this.h=h;
 }
 catch(err)
   {
   txt="There was an error on this page.\n\n";
   txt+="Error description: " + err.message + "\n\n";
   txt+="Click OK to continue.\n\n";
   alert(txt);
   }
 }
