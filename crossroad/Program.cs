using Raylib_cs;
using System.Numerics;


int screenwidht = 1550;
int screenhight = 800;


Raylib.InitWindow(screenwidht, screenhight, "fun games");
Raylib.SetTargetFPS(60);


// string curentscreen = "";
// Thing test = new Thing();

//  movementSprites
Rectangle player = new Rectangle(1500 / 2, 750, 50, 50);
Rectangle test = new Rectangle(2000 / 2, 500, 50, 50);

// Random genarator =

while (!Raylib.WindowShouldClose())
{
    player.y++;


    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.WHITE);

    Raylib.DrawRectangleRec(player, Color.YELLOW);
    Raylib.DrawRectangleRec(test, Color.BROWN);




    if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
    {
        player.x -= 75;
    }
    if (player.x < 0)
    {
        player.x = 0;
    }


    if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
    {
        player.x += 75;
    }
    if (player.x >= 1550)
    {
        player.x = 1550;
    }
    
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
    {
        player.y -= 75;
    }
    if (player.y <= 0)
    {
        player.y = 0;
    }
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
    {
        player.y += 75;
    }
    if (player.y >= 750)
    {
            player.y -= 75;
    }
        

    // if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
    // {
    //     player.y -= 75;
    // }
    // if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
    // {
    //     player.y += 75;
    // }
    // if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
    // {
    //     player.x -= 75;
    // }
    // if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
    // {
    //     player.x += 75;
    // }
    // if (player.x >= screenwidht || player.x <= -screenwidht || player.y >= screenhight || player.y <= -screenhight ){

    // if(Raylib.IsKeyPressed(KeyboardKey.KEY_W)){
    //     player.y += 75;
    // }
    // if(Raylib.IsKeyPressed(KeyboardKey.KEY_S)){
    //     player.y -= 75;
    // }
    // if(Raylib.IsKeyPressed(KeyboardKey.KEY_A)){
    //     player.x += 75;
    // }
    // if(Raylib.IsKeyPressed(KeyboardKey.KEY_D)){
    //     player.x -= 75;
    // }

    // }






    Raylib.EndDrawing();
}


