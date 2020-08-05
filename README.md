# vs-files-cleaner
An app that cleans bin/obj folders 

[Imgur](https://imgur.com/RI93KRi)

# Usage
Compile solution and run the `VsFilesCleaner.exe` in the folder that you want to check.

# Using as a scheduled task

There's another project in the same solution that doesn't ask anything and does the job by passing the path as an argument, so basically create a scheduled job that runs `VsFilesCleanerTask.exe` with a parameter being a directory path.


