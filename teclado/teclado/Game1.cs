using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D teclado, cuadrado, enter;

        SpriteFont letras;
        
        int xpantalla, ypantalla;

        string[,] matriz = new string[10,4];

        int xmatriz, ymatriz,tamañomarcox, tamañomarcoy, cordmarcox, cordmarcoy;
        int pos = -1;
        int sacabarra = 0;

        string frase = "";

        bool teclapresionada, escribir;
        bool visto = true;
        bool mostrar = true;

        double texpantalla = 0;
        double intervalo = 1000;




        KeyboardState previmiento;

        public Game1()
        {
            Content.RootDirectory = "Content";

            xpantalla = 900;
            ypantalla = 600;

            xmatriz = 0;
            ymatriz = 0;


            tamañomarcox = 83;
            tamañomarcoy = 143;
            cordmarcox = 30;
            cordmarcoy = 30;

            matriz[0, 0] = "Q";
            matriz[0, 1] = "A";
            matriz[0, 2] = "Z";
            matriz[0, 3] = "ESPACIO";

            matriz[1, 0] = "W";
            matriz[1, 1] = "S";
            matriz[1, 2] = "X";
            matriz[1, 3] = "ESPACIO";

            matriz[2, 0] = "E";
            matriz[2, 1] = "D";
            matriz[2, 2] = "C";
            matriz[2, 3] = "ESPACIO";

            matriz[3, 0] = "R";
            matriz[3, 1] = "F";
            matriz[3, 2] = "V";
            matriz[3, 3] = "ENTER";

            matriz[4, 0] = "T";
            matriz[4, 1] = "G";
            matriz[4, 2] = "B";
            matriz[4, 3] = "ENTER";

            matriz[5, 0] = "Y";
            matriz[5, 1] = "H";
            matriz[5, 2] = "N";
            matriz[5, 3] = "ENTER";

            matriz[6, 0] = "U";
            matriz[6, 1] = "J";
            matriz[6, 2] = "M";
            matriz[6, 3] = "BORRAR";

            matriz[7, 0] = "I";
            matriz[7, 1] = "K";
            matriz[7, 2] = "IZ";
            matriz[7, 3] = "BORRAR";

            matriz[8, 0] = "O";
            matriz[8, 1] = "L";
            matriz[8, 2] = "DER";
            matriz[8, 3] = "BORRAR";

            matriz[9, 0] = "P";
            matriz[9, 1] = "Ñ";
            matriz[9, 2] = "DER";
            matriz[9, 3] = "BORRAR";

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            //Tamaño de la venta
            graphics.PreferredBackBufferWidth = xpantalla;
            graphics.PreferredBackBufferHeight = ypantalla;

            IsMouseVisible = true;
            graphics.ApplyChanges();
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            teclado = Content.Load<Texture2D>("A");
            cuadrado = Content.Load<Texture2D>("cuadrado1");
            enter = Content.Load<Texture2D>("enter (1)");

            letras = Content.Load<SpriteFont>("Fonts/ZTTalk-Bold"); //("Fonts/arial")







            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            KeyboardState chequeo = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (chequeo.IsKeyUp(Keys.Down) && teclapresionada && chequeo.IsKeyUp(Keys.Up) && chequeo.IsKeyUp(Keys.Right) && chequeo.IsKeyUp(Keys.Left) && chequeo.IsKeyUp(Keys.Enter))
            {

                escribir = false;
                teclapresionada = false;
                
            }
            if (chequeo.IsKeyDown(Keys.Down) && !teclapresionada)
            {
                if (ymatriz< 4)
                {
                    
                    ymatriz += 1;
                    
                }
                else
                {
          
                    ymatriz = 0;

                }
                teclapresionada = true;
            }
            



            if (chequeo.IsKeyDown(Keys.Up) && !teclapresionada)
            {
                if (0 < ymatriz)
                {
                    ymatriz -= 1;
                }
                else
                {
                    ymatriz = 3;
                }
                teclapresionada = true;

            }
            if (chequeo.IsKeyDown(Keys.Right) && !teclapresionada)
            {
                if (matriz[xmatriz, ymatriz] != "ESPACIO" && matriz[xmatriz, ymatriz] != "BORRAR" && matriz[xmatriz, ymatriz] != "ENTER" && matriz[xmatriz, ymatriz] != "DER")
                {
                    if (xmatriz < 10)
                    {
                        xmatriz += 1;
                    }
                    else
                    {
                        xmatriz = 0;
                    }
                }else if (matriz[xmatriz, ymatriz] == "ESPACIO")
                {
                    xmatriz = 4;
                }else if (matriz[xmatriz, ymatriz] == "ENTER")
                {
                    xmatriz = 7;
                }else if (matriz[xmatriz, ymatriz] == "BORRAR")
                {
                    xmatriz = 1;
                }else if (matriz[xmatriz, ymatriz] == "DER")
                {
                    xmatriz = 0;
                }




                teclapresionada = true;

            }
            if (chequeo.IsKeyDown(Keys.Left) && !teclapresionada)
            {
                if (matriz[xmatriz, ymatriz] != "ESPACIO" && matriz[xmatriz, ymatriz] != "BORRAR" && matriz[xmatriz, ymatriz] != "ENTER")
                {
                    if (0 < xmatriz)
                    {
                        xmatriz -= 1;
                    }
                    else
                    {
                        xmatriz = 9;
                    }
                }
                else if (matriz[xmatriz, ymatriz] == "ESPACIO")
                {
                    xmatriz = 7;
                }
                else if (matriz[xmatriz, ymatriz] == "ENTER")
                {
                    xmatriz = 1;
                }
                else if (matriz[xmatriz, ymatriz] == "BORRAR")
                {
                    xmatriz = 4;
                }

                    

                    teclapresionada = true;

            }
            if (chequeo.IsKeyDown(Keys.Enter) && !teclapresionada)
            {

                escribir = true;
                teclapresionada = true  ;
            }




            previmiento = chequeo;


            texpantalla += gameTime.ElapsedGameTime.TotalMilliseconds;
            
            if (texpantalla >= intervalo)
            {

            } 
            



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //zona de dibujado
            spriteBatch.Begin();

            spriteBatch.Draw(teclado,
                            new Rectangle(0, 0, xpantalla, ypantalla),
                             Color.White);


            if (ymatriz == 4)
            {
                ymatriz = 0;
            }
            if (xmatriz == 10)
            {
                xmatriz = 0;
            }

            switch (matriz[xmatriz, ymatriz])
            {
                case "Q":
            
                    cordmarcox = 55;
                    cordmarcoy = 83;

                    tamañomarcox = 83;
                    tamañomarcoy = 133;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);

                    if (escribir == true)
                    {
                        frase += "Q";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }

                    break;
                case "A":
            

                    cordmarcox = 55;
                    cordmarcoy = 217;

                    tamañomarcox = 83;
                    tamañomarcoy = 133;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "A";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
                
                case "Z":
                    

                    cordmarcox = 55;
                    cordmarcoy = 345;

                    tamañomarcox = 90;
                    tamañomarcoy = 150;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "Z";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
                case "ESPACIO":
            
                    cordmarcox = 37;
                    cordmarcoy = 495;

                    tamañomarcox = 350;
                    tamañomarcoy = 95;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += " ";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }

                    break;

                //X=0

                case "W":
            
                    cordmarcox = 135;
                    cordmarcoy = 83;

                    tamañomarcox = 83;
                    tamañomarcoy = 133;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "W";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }

                    break;
                case "S":
            
                    cordmarcox = 135;
                    cordmarcoy = 217;

                    tamañomarcox = 83;
                    tamañomarcoy = 133;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);

                    if (escribir == true)
                    {
                        frase += "S";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
                case "X":
            
                    cordmarcox = 144;
                    cordmarcoy = 350;

                    tamañomarcox = 83;
                    tamañomarcoy = 142;

                    spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);

                    if (escribir == true)
                    {
                        frase += "X";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;

            //X=1

            case "E":
            
                cordmarcox = 215;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "E";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "D":
            
                cordmarcox = 218;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "D";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "C":
            
                cordmarcox = 230;
                cordmarcoy = 350;

                tamañomarcox = 83;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "C";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            //X=2

            case "R":
            
                cordmarcox = 295;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "R";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "F":
            
                cordmarcox = 298;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "F";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "V":
            
                cordmarcox = 317;
                cordmarcoy = 350;

                tamañomarcox = 83;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "V";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "ENTER":
            
                cordmarcox = 355;
                cordmarcoy = 480;

                tamañomarcox = 237;
                tamañomarcoy = 120;

                spriteBatch.Draw(enter, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    break;
            //X=3
            case "T":
            
                cordmarcox = 375;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "T";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "G":
            
                cordmarcox = 380;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "G";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "B":
            
                cordmarcox = 402;
                cordmarcoy = 350;

                tamañomarcox = 83;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "B";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            //X=4
            case "Y":
            
                cordmarcox = 455;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "Y";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "H":
            
                cordmarcox = 462;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "H";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "N":
            
                cordmarcox = 489;
                cordmarcoy = 350;

                tamañomarcox = 83;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "N";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            //X=5
            case "U":
            
                cordmarcox = 535;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "U";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "J":
            
                cordmarcox = 544;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "J";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "M":
            
                cordmarcox = 575;
                cordmarcoy = 350;

                tamañomarcox = 83;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "M";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "BORRAR":
            
                cordmarcox = 570;
                cordmarcoy = 500;

                tamañomarcox = 270;
                tamañomarcoy = 90;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true && pos > -1)
                    {
                        frase = frase.Remove((pos), 1);
                        pos--;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    } 
                    
                    break;
            //X=6
            case "I":
            
                cordmarcox = 615;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "I";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "K":
            
                cordmarcox = 624;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "K";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "IZ":
            
                cordmarcox = 660;
                cordmarcoy = 350;

                tamañomarcox = 85;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    break;
            //X=7
            case "O":
            
                cordmarcox = 695;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "O";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "L":
            
                cordmarcox = 706;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "L";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "DER":
            
                cordmarcox = 745;
                cordmarcoy = 350;

                tamañomarcox = 85;
                tamañomarcoy = 142;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    break;
            //X=8
            case "P":
            
                cordmarcox = 775;
                cordmarcoy = 83;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "P";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;
                    }
                    break;
            case "Ñ":
            
                cordmarcox = 787;
                cordmarcoy = 217;

                tamañomarcox = 83;
                tamañomarcoy = 133;

                spriteBatch.Draw(cuadrado, new Rectangle(cordmarcox, cordmarcoy, tamañomarcox, tamañomarcoy), Color.White);
                    if (escribir == true)
                    {
                        frase += "Ñ";
                        pos += 1;
                        sacabarra = frase.IndexOf('|');
                        frase = frase.Remove(sacabarra, 1);
                        visto = true;
                        escribir = false;

                    }
                    break;

                
        

        }


            //hacer que cada un segundo por ejemplo desapazreca y aparazca constantemente

            if (visto == true)
            {
                frase = frase.Insert(frase.Length, "|".ToString());
                visto = false;
            }

            spriteBatch.DrawString(letras, frase, new Vector2(68, 15), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
