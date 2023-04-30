using Raylib_cs;

public static class Playermovment
{

  
       public static void Movment() // spelarens rörelse 
    {
        Logic.player.y++; //logic refererar till kåden i andra filen  
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
        {
            Logic.player.x -= 75;
        }
        if (Logic.player.x <= 0)
        {
            Logic.player.x = 0;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
        {
            Logic.player.x += 75;
        }
        if (Logic.player.x >= 1550)
        {
            Logic.player.x = 1500;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
        {
            Logic.player.y -= 75;
        }
        if (Logic.player.y <= 0)
        {
            Logic.player.y = 0;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
        {
            Logic.player.y += 75;
        }
        if (Logic.player.y >= 750)
        {
            Logic.player.y -= 75;
        }

        return; 
    }


}

