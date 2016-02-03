var BibleContent = function(content, day,image)
{
    this.content = content;
    this.day = day;
    if(image==null)
    {
        this.image = "Resource/Image/hellp.jpg";
    }
    else
    {
        this.image = image;
    }
    
}

var PriestInfo = function(name,photoPath,thinking)
{
    this.name = name;
    if(photoPath==null)
    {
        this.phptoPath = "Resource/Image/hellp.jpg";
    }
    else
    {
        this.photoPath = photoPath;
    }
    this.thinking = thinking;
}