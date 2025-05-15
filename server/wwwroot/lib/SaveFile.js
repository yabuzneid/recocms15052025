function FileSaveAs(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = fileContent;
    document.body.appendChild(link);
    link.innerText = "Download";
    //link.click();
    //document.body.removeChild(link);
}