using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFrameApp.Models;

namespace WebFrameApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Spiral(bool ordered = false)
        {
            // Goal is to move x & y pointers into array to then just
            // add the letters of those positions to the end of the result string

            ViewBag.Message = "Spiral array print page.";

            var model = new SpiralModel
            {
                Id = 0,
                ordered = false,
                result = new String(' ', 50),
                arr = new List<List<string>>()
            };

            // build the matrix so that if it was printed in a spiral fashion clockwise,
            // the natural order of the alphabet would be displayed
            model.arr.Add(new List<string>() { "a", "b", "c", "d", "e" });
            model.arr.Add(new List<string>() { "p", "q", "r", "s", "f" });
            model.arr.Add(new List<string>() { "o", "x", "y", "t", "g" });
            model.arr.Add(new List<string>() { "n", "w", "v", "u", "h" });
            model.arr.Add(new List<string>() { "m", "l", "k", "j", "i" });

            if (model.arr.Any())
            {
                var height = model.arr.Count;
                var width = model.arr[0].Count;
                var startx = 0;
                var starty = 0;
                var length = height * width;

                if (ordered)
                {
                    model.result = "";
                    var x = 0;
                    var y = 0;
                    // right = 0
                    // down  = 1
                    // left  = 2
                    // up    = 3
                    var direction = 0;

                    for (var i = 0; i < length; i++)
                    {
                        model.result += model.arr[y][x];

                        switch (direction)
                        {
                            case 0: // right

                                // do we need to change direction?
                                if (i > startx && i % (width-1) == 0)
                                {
                                    direction++; // change direction to go down
                                    // have to move as you already printed at this y
                                    y++; 
                                }else
                                {
                                    x++;
                                }
                        
                                break;
                            case 1: // down

                                // do we need to change direction?
                                if (y > starty && y % (height-1) == 0)
                                {
                                    direction++; // change direction to go left
                                    // will never be this wide again
                                    width--;
                                    // have to move as you already printed at this x
                                    x--;
                                }
                                else
                                {
                                    y++;
                                }
                                break;
                            case 2: // left

                                // do we need to change direction?
                                if (x == startx)
                                {
                                    direction++; // change direction to go up
                                    // will never be this far down again
                                    height--;
                                    // have to move up for next print
                                    y--;
                                }
                                else
                                {
                                    x--;
                                }
                                break;
                            case 3: // up

                                // do we need to change direction?
                                if (y == starty + 1)
                                {
                                    // change direction to go right
                                    direction = 0;
                                    // will never be this high again
                                    starty++;
                                    // will never be this far left again
                                    startx++;
                                    // have to move right for next print
                                    x++;
                                }
                                else
                                {
                                    y--;
                                }
                                break;
                        }
                      
                    }
                }
                else
                {
                    // just print rows out in default order
                    var y = -1;
                    model.result = "";
                    for (var i = 0; i < length; i++)
                    {
                        var x = i % width;
                        if(x == 0)
                        {
                            y++;
                        }
                        model.result += model.arr[y][x];
                    }
                }
            }
            return View(model);
        }
    }
}