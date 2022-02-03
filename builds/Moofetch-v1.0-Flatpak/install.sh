#!/bin/bash 

echo "Installing Moofetch..."
flatpak install moofetch.flatpak
echo "Adding alias to rc file..."
echo "alias moofetch='flatpak run org.flatpak.Moofetch' # Added by Moofetch's install script" >> "/home/$USER/.${SHELL##*/}rc"
echo "Finished."
