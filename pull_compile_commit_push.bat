@echo off
git pull
pdflatex projectSample.tex
git add -A
git commit -m "Updated pdf"
git push origin main