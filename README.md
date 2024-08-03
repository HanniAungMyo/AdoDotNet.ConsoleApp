C#
.net Framework (Windows)

.net Core (Windows,Linux,Mac)
.1
.2
.2.2
.3
.3.1
.4


.net
.5 (vs19,vs2022)
.6(vscode vs2022)
.7(current)
.8
.9(Beta)

.console App
.Window Form
.asp.net web Forms
.asp.net core  web mvc Forms
.asp.net core web api


Bird Select//No method Split
 List<BirdViewModel> list = birds.Select(bird => new BirdViewModel
                {
                   BirdId = bird.Id,
                    BirdName = bird.BirdMyanmarName,
                    Desc = bird.Description,
                   PhotoUrl = $"$"https://burma-project-ideas.vercel.app/{bird.ImagePath}",
                }).ToList();
                List<BirdViewModel> list = birds.Select(bird => Change(bird)).ToList();
                List<BirdViewModel> list = birds.Select(bird =>Change(bird)).ToList();


                 var item = new BirdViewModel
                {
                    BirdId = bird.Id,
                    BirdName = bird.BirdMyanmarName,
                   Desc = bird.Description,
                    PhotoUrl = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"
                };


