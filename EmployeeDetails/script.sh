#!/bin/bash

while true; do
    echo 
    echo "-------------------------------------------"
    echo "Press 1 to restart a employeeDetailsApi service"
    echo "Press 2 to view status of the employeeDetailsApi service"
    echo "Press 3 to build a release version"
    echo "Press 0 to exit"
    echo "-------------------------------------------"
    echo -n "Your choice: "
    read choice
    echo 


    case "$choice" in
        1)
            echo vivid | sudo -S systemctl restart employeeDetailsApi
            ;;
        2)
            echo vivid | sudo -S systemctl status employeeDetailsApi
            ;;
        3)
            # Execute the release script (replace with the actual script name)
            sh deploy.sh
            ;;
        0)
            echo "Exiting the script. Goodbye!"
            exit 0
            ;;
        *)
            echo "Invalid choice. Please press 1, 2, or 0."
            ;;
    esac
done
