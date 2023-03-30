using Raylib_cs;
using System.Numerics;


int screenwidht= 1550;
int screenhight= 800;


Raylib.InitWindow(screenwidht, screenhight, "fun games");
Raylib.SetTargetFPS(60);


// string curentscreen = "";
// Thing test = new Thing();

//  movementSprites
Rectangle player = new Rectangle(1500/2, 750, 50, 50);

List<Rectangle> walls = new List<Rectangle>();
walls.Add(new Rectangle(1500,800, 100, -1500));
walls.Add(new Rectangle(1500,0, 100, 1500));
walls.Add(new Rectangle(0,800, 100, 1500));
walls.Add(new Rectangle(0,0, 100, 1500));

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.WHITE);
    
    Raylib.DrawRectangleRec(player,Color.YELLOW);

    if (player.x >= screenwidht || player.x <= -screenwidht || player.y >= screenhight || player.y <= -screenhight ){
        
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_W)){
        player.y += 75;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_S)){
        player.y -= 75;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_A)){
        player.x += 75;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_D)){
        player.x -= 75;
    }

    }
    else {
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_W)){
        player.y -= 75;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_S)){
        player.y += 75;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_A)){
        player.x -= 75;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_D)){
        player.x += 75;
    }

    }

    //        foreach (Rectangle wall in walls)
    // {
    //     Raylib.DrawRectangleRec(wall, Color.BLACK);
    // }
    
        Raylib.EndDrawing();
    }


  