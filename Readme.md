# Intro Dialog Pager

This library is a simple intro dialog to help quickly show users your apps functions. 

### Usage

Create an array of `IntroFrame` objects defining each 'page' in your intro. 
```c#
var IntroPager = new IntroPager(this);
var pages = IntroFrame[]{
        new IntroFrame()
                {
                    Title = "Thank You",
                    Message = "Thank you for trying out my app!",
                    ImageResource = Resource.Mipmap.ic_launcher,
                    BackroundResource = Resource.Drawable.geometric_background,
                    OnEndCallback = () =>
                    {
                        IntroPager.Dismiss();
                    }
                }
IntroPager.Build(pages);
}
```
If you leave OnEndCallback null it will not show the button.