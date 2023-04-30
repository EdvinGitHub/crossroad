using Raylib_cs;

Raylib.InitWindow(1550, 800, "fun games"); //storleken på fönstret
Raylib.SetTargetFPS(60); //sätter hur många frames per sekund


while (!Raylib.WindowShouldClose()){ // vart kåden körs
    Logic.Update();
    Raylib.BeginDrawing();
    Logic.Render();
    Raylib.EndDrawing();
}

public static class Logic{ // vart kåden för logicen av spelet är

static public Rectangle player = new Rectangle(1500 / 2, 750, 50, 50); // splarens retangel
static Rectangle enamys = new Rectangle(2000 / 2, -50, 50, 50); // fienden som man ska undvika  
static Rectangle enamys2 = new Rectangle(300, -50, 50, 50); // andra fienden som man ska undvika  

static List<Rectangle> background = new List<Rectangle>(); // bakrunden för spelet

static Rectangle background1 = new Rectangle(0, -100, 1550, 100);
static Rectangle background2 = new Rectangle(0, -100, 1550, 100);
static Rectangle background3 = new Rectangle(0, -100, 1550, 100);
static Rectangle background4 = new Rectangle(0, -100, 1550, 100);
static Rectangle background5 = new Rectangle(0, -100, 1550, 100);
static Rectangle background6 = new Rectangle(0, -100, 1550, 100);
static Rectangle background7 = new Rectangle(0, -100, 1550, 100);
static Rectangle background8 = new Rectangle(0, -100, 1550, 100);
static Rectangle background9 = new Rectangle(0, -100, 1550, 100);

static Random genarator = new Random(); // ger en random numer från 0 till vilket numer man valde

static int i1 = 0; // i1 ska bestäma vilket håll fienderna ska åka
static int i2= 0; // i2 ska vara för att skapa alla figurer i spelat 
static int start= 1; // start är för att veta när man startar spelets introdution   
static int hp = 3; // spelarens hp 
static double hp2 = 0.5; //inte spelarens hp men ska hjälpa att när man tar skada  
static float enamyX = 100; // vart ena fienden.x kommer att vara ibörjan kommer också att användas för andra anledningar senare
static float enamyX2 = 500; // vart andra fienden.x kommer att vara ibörjan kommer också att användas för andra anledningar senare
static float enamyY = 0; // var ena fienden.y kommer att vara i början 
static float enamyY2 = 0; // var ena fienden.y kommer att vara i början 
static float enamyspeed1 = 0; // x hastigheten för ena fienden 
static float enamyspeed2 = 0; // x hastigheten för andra fienden 

static List<Rectangle> enamy = new List<Rectangle>(); // listan där fienden kommer vara inne i 

static int timer = 0; // timer för när fienderna hamnar utanför spel fönstret halft
static int score = 0; // håller koll på hur länge man hamnade 

static public void Update() // vart kåden ändras 
{
    if (hp2 <=0)
    {
        if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            hp2++;
            i2--;
        } 
    }
    if (hp <= 0) // kör när man har förlorat alla sina HP
    {
        if (hp2 <=0) // skapa en timer för när spelet ska stängas av 
        {
        timer = 300;
        }
        timer--;
        hp2 = 0.5;
        if(timer <= 0)
        {
            Raylib.CloseWindow(); // stänger av spelet 
        }
    }
    if(start == 1) // vad som först sätts igång när spelet startar 
    {
        if(Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) 
        {
            hp2 = 1; // gör så att ritiga spelet börja 
            start = 0; // gör så att spelet inte bugas om man trycker på enter senare
        }
    }
    else if (hp2 >= 1) // om man har inte tagit skada eller om man har förlorat 
    {

    while (i2 == 0) // skapar all retanglar i lister 
    {
        enamy.Add(enamys = new Rectangle(enamyX, enamyY2, 100, 50));
        enamy.Add(enamys2 = new Rectangle(enamyX2, enamyY, 100, 50));

        background.Add(background1 = new Rectangle(0, 0, 1550, 100));
        background.Add(background2 = new Rectangle(0, 100, 1550, 100));
        background.Add(background3 = new Rectangle(0, 200, 1550, 100));
        background.Add(background4 = new Rectangle(0, 300, 1550, 100));
        background.Add(background5 = new Rectangle(0, 400, 1550, 100));
        background.Add(background6 = new Rectangle(0, 500, 1550, 100));
        background.Add(background7 = new Rectangle(0, 600, 1550, 100));
        background.Add(background8 = new Rectangle(0, 700, 1550, 100));
        background.Add(background9 = new Rectangle(0, -100, 1550, 100));
        i2++;
    }
    Playermovment.Movment(); // rörelsen för spelaren 
    score++; // hur länge man har över levt 
    enamys.y++; // gör så att fienden åker neråt 
    enamys2.y++; // gör så att fienden åker neråt 
    enamys.x += enamyspeed1; // gör så att fienden åker åt höger när jag säger till dom
    enamys2.x += enamyspeed2; // gör så att fienden åker åt höger när jag säger till dom
    timer++; // säger till när fienden ska flyta säg när de är utan för skärmen 
    background1.y++; // gör så att backrunden åker neråt 
    background2.y++; 
    background3.y++;
    background4.y++;
    background5.y++;
    background6.y++;
    background7.y++;
    background8.y++;
    background9.y++;

    if (enamyspeed1 >= 0) // gör så att fiende 1 kommer att åka neråt snabbare 
    {
        enamys.y += 3;
    }
    if (enamyspeed2 == 0) // samt gör samma fast bara när de inte åker åt höger 
    {
        enamys2.y += 3;
    }

    if (timer >= 60)//kollar varje secund om fienderna är utanför fönstret
    {
        timer = 0; // gör så att den ite kollar om fienderna är utanför fönstret 
        i1 = genarator.Next(2); // gör så att i1 kan vara två olika numer 1 och 0 
        enamyX2 = enamys.x; // används för att göra t.ex enamyX2 blir något annat än vad det var innan
        enamyX = enamys2.x; // används för att göra t.ex enamyX blir något annat än vad det var innan
        enamyY2 = enamys.y; // används för att göra t.ex enamyY2 blir något annat än vad det var innan
        enamyY = enamys2.x; // används för att göra t.ex enamyy blir något annat än vad det var innan
        if (enamys2.x >= 1500) // kolar om en fiände är utanför fönstret på högra sidan
        {
            enamyX2 = -100; // görs för så man vet om fienden var utanför fönstret 
        }
        if (enamys.x >= 1500)  // kolar om en fiände är utanför fönstret på högra sidan
        {
            enamyX = -100; // görs för så man vet om fienden var utanför fönstret 
        }
        if (enamys.y >= 800) // kolar om en fiände är utanför fönstret neråt
        {
            enamyX = -100; // görs för så man vet om fienden var utanför fönstret 
        }
        if (enamys2.y >= 800) // kolar om en fiände är utanför fönstret neråt
        {
            enamyX2 = -100; // görs för så man vet om fienden var utanför fönstret 
        }
        if (i1 == 0) // används för att om fienden var utanför fönstret så kommer fänden att börja längst upp men på X axeln kommer vara lite överallt 
        {

            if (enamyX <= -50)
            {
                enamys.x = genarator.Next(1400);
                enamyX = enamys.x;
                enamys.y = 0;
                enamyspeed1 = 0;
            }
            if (enamyX2 <= -50)
            {
                enamys2.x = genarator.Next(1400);
                enamyX2 = enamys2.x;
                enamys2.y = 0;
                enamyspeed2 = 0;
            }
        }
        if (i1 == 1) // samt om fienden är utanför fönstret men att det är på Y axeln istälet för X axeln  
        {

            if (enamyX <= -50)
            {
                enamyspeed1 = 8;
                enamys.y = genarator.Next(400);
                enamys.x = 0;
                enamyX = enamys.x;
            }
            if (enamyX2 <= -50)
            {
                enamyspeed2 = 8;
                enamys2.y = genarator.Next(400);
                enamys2.x = 0;
                enamyX2 = enamys2.x;

            }
        }
    }
        if (Raylib.CheckCollisionRecs(enamys,player)) {  // kollar om fienden och spelaren nudar varandra 
            hp--; // minskar hp 
            hp2--; // gör så att spelet stopas till man väljer att starta den igen 
            
            }
        else if (Raylib.CheckCollisionRecs(enamys2,player)){   // kollar om fienden och spelaren nudar varandra 
            hp--;   // minskar hp 
            hp2--;  // gör så att spelet stopas till man väljer att starta den igen 
            }
    }
    if(background1.y >=800)//kollar om bakrunden är utanför fönstret +9
    {background1.y = -100;}
    if(background2.y >=800)
    {background2.y = -100;}
    if(background3.y >=800)
    {background3.y = -100;}
    if(background4.y >=800)
    {background4.y = -100;}
    if(background5.y >=800)
    {background5.y = -100;}
    if(background6.y >=800) 
    {background6.y = -100;}
    if(background7.y >=800)
    {background7.y = -100;}
    if(background8.y >=800)
    {background8.y = -100;}
    if(background9.y >=800)
    {background9.y = -100;}
}
static public void Render(){ // används för att skriva ut alla efekter/figurer
    
    if(start == 1) // skriver saker när spelet börjar
    {
        Raylib.DrawText("wellcome to the true crossroad",500, 100, 30,Color.GREEN);
        Raylib.DrawText("avoid the blue boxes and survive as long as you can",400, 300, 30,Color.GREEN);
        Raylib.DrawText("press ENTER to start the game",500, 500, 30,Color.GREEN);

        Raylib.ClearBackground(Color.BLACK); 
    }
    if (hp2 >= 1) // när spelet har börjat så kommer den att skriva ut alla saker som spelaren och fienderna
    {
        Raylib.DrawRectangleRec(background1, Color.BEIGE);
        Raylib.DrawRectangleRec(background2, Color.DARKGRAY);
        Raylib.DrawRectangleRec(background3, Color.DARKBROWN);
        Raylib.DrawRectangleRec(background4, Color.BEIGE);
        Raylib.DrawRectangleRec(background5, Color.DARKGRAY);
        Raylib.DrawRectangleRec(background6, Color.DARKBROWN);
        Raylib.DrawRectangleRec(background7, Color.BEIGE);
        Raylib.DrawRectangleRec(background8, Color.DARKGRAY);
        Raylib.DrawRectangleRec(background9, Color.DARKBROWN);
        Raylib.DrawText("Hp"+hp+" avoid the rectangles",1200,50,25,Color.GRAY);
        Raylib.DrawText("youre score is "+score/60,1250,200,30,Color.GRAY);
        Raylib.DrawRectangleRec(enamys, Color.BLUE);
        Raylib.DrawRectangleRec(enamys2, Color.BLUE);
        Raylib.DrawRectangleRec(player, Color.YELLOW);
        Raylib.ClearBackground(Color.WHITE);
    }
    if (hp <=0) // skriver sakerna när man harförlorat
    {
        Raylib.DrawText("you lost game vill close in "+timer/60 , 1550/2, 400, 30, Color.GREEN);
        Raylib.ClearBackground(Color.BLACK);

    }
    else if(hp2 <=0) // skriver ut saker när man har tagit skada inte när man är död 
    {
        Raylib.DrawText("you got hit press SPACE to continue playing", 1550/2, 400, 30, Color.GREEN);
        Raylib.ClearBackground(Color.BLACK);
    }
    
}
}
