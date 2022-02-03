#!/bin/bash 

echo "Adding alias to rc file..."
echo "alias moofetch='$PWD/moofetch' # Added by Moofetch's install script" >> "/home/$USER/.${SHELL##*/}rc"
echo "Finished."
