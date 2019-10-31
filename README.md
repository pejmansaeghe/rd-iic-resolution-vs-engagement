# WORK IN PROGRESS

# rd-iic-resolution-vs-engagement
Experimental software for testing how display resolution affects viewer engagement using secondary task reaction time.

## Instructions
### Experiment concept 
The experiment involves showing users a series of videos, during which short audio tones are are played. The user is instructed to press a button on an input device (such as a game controller) whenever they hear one of the audio tones. The button to press depends on which particular tone they heard. The time taken for the user to press a button is measured.
The hypothesis is that the more engaging a piece of video content is, the longer it will take for the user to respond to the audio tone (and possibly their accuracy in pressing the correct button will also suffer).

### Setup
A configuration file called *config.json* describing which videos should be shown to which participant should be prepared and placed in the persistent storage folder of the application. In Windows, this is *C:\Users\[username]\AppData\LocalLow\rd_bbc_co_uk\ResolutionEngagement*.

The format of the configuration file should be:

``` 
{
    "experimentConfigurations": [
        {
            "experimentNumber":0,
            "videoUrls":["lion_full.mp4", "seal_half.mp4", "badger_low.mp4"]
        },
        {
            "experimentNumber":1,
            "videoUrls":["lion_half.mp4", "seal_low.mp4", "badger_full.mp4"]
        },
        {
            "experimentNumber":2,
            "videoUrls":["lion_low.mp4", "seal_full.mp4", "badger_half.mp4"]
        }
    ]
}
```


.................More......................
