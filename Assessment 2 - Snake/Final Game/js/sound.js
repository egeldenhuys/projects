 function PlaySound(id) {
	try {
		var sound = document.getElementById(id);
		sound.play();
		}
	catch(err)
		{
		console.log(err.message);
		}
	
 }
 