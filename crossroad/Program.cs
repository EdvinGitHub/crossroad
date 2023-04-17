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
Rectangle enamys = new Rectangle(2000 / 2, 500, 50, 50);
Rectangle enamys2 = new Rectangle(1800 / 2, 500, 50, 50);

Random genarator = new Random();

// i1 ska bestäma vilket håll fienderna ska åka
// i2 ska 
int i1 = 0;
int i2= 0;

float enamyX = 0;
float enamyX2 = 0;

// Timer timer1 = new Timer(1000);
// int enamyhight = 0;
float enamyY = 0;
float enamyY2 = 0;
float enamyspeed = 0;
// genarator.Next(screenhight)
List<Rectangle> enamy = new List<Rectangle>();



// om min timer fungerar ska den här kåden köras



int timer = 0;


while (!Raylib.WindowShouldClose())
{
    player.y++;

    timer++;
    
    enamys.y += 4;
    enamys2.y += 4;

    enamys.x += enamyspeed;
    enamys2.x += enamyspeed;
    while(i2 == 0)
    {
            enamy.Add(enamys = new Rectangle(enamyX,enamyY2,100,50));
            enamy.Add(enamys2 = new Rectangle(enamyX2,enamyY,100,50));
            i2++;
    }

    if (timer>60)
    {
        timer = 0;
        // gör nåt
        i1 = genarator.Next(2);
        if(i1 == 0)
        {   
            enamyY2 = enamys.y; 
            enamyY = enamys2.x; 

            if(enamys2.x>=1500)
            {
            enamys2.y = 0;
            enamyX2 = -100;
            }
            if(enamys.x>=1500)
            {
            enamys.y = 0;
            enamyX = -100;
            }
            if(enamys.y >= 800)
            {
            enamys.y = 0;
            enamyX = -100;
            }
            if(enamys2.y >= 800)
            {
            enamys2.y = 0;
            enamyX2 = -100;
            }
            if(enamys.x <= -100) {
            enamys.x = genarator.Next(1400);
            enamyX = enamys.x;
            }
            else if(enamys2.x <= -100)
            {
            enamys2.x = genarator.Next(1400);
            enamyX2 = enamys2.x;
            // enamyX = genarator.Next(1500);
            // enamy.Add(enamys = new Rectangle(enamyX,enamyY2,100,50));
                enamyspeed = 0;
            }
        }
        if(i1==1)
        {   
            enamyX2 = enamys.x;
            enamyX = enamys2.x;
            if(enamys.x>=1500)
            {
                enamys.x = -100;
            }
            if(enamys.y >= 800)
            {
                enamys.x = -100;
                
            }
            if(enamys.x <= -100)
            {
            enamyspeed = 8;
            enamys.y = genarator.Next(400);
            enamyY = enamys.y;
            }
        }
    }


    if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
    {
        player.x -= 75;
    }
    if (player.x <= 0)
    {
        player.x = 0;
    }


    if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
    {
        player.x += 75;
    }
    if (player.x >= 1550)
    {
        player.x = 1500;
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
            player.y -= 70;
    }

    if (Raylib.CheckCollisionRecs(enamys,player))
    {
    Raylib.DrawRectangleRec(player, Color.BROWN);
    Raylib.DrawRectangleRec(enamys, Color.YELLOW);
    Raylib.DrawRectangleRec(enamys2, Color.YELLOW);
    Raylib.ClearBackground(Color.WHITE);
        
    }
    else
    {
    Raylib.DrawRectangleRec(player, Color.YELLOW);
    Raylib.DrawRectangleRec(enamys, Color.BROWN);
    Raylib.DrawRectangleRec(enamys2, Color.BROWN);
    Raylib.ClearBackground(Color.WHITE);

    }

    Raylib.BeginDrawing();


    // Raylib.DrawRectangleRec(edwanamy, Color.BLUE);

          



    Raylib.EndDrawing();
}


