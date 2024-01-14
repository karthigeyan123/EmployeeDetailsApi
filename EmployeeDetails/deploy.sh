RELEASE_FOLDER_PATH='../../Release/EmployeeDetailsAPI/'

#? pull from origin
# git pull origin main

#! password
echo vivid

#? delete existing release file
# sudo -S rm -r $RELEASE_FOLDER_PATH*

# ? publis in release mode
dotnet publish --configuration Release --output $RELEASE_FOLDER_PATH

