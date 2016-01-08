for i=1:29
    filename = ['plaster4s_color',num2str(i),'.png'];
[I,map,alpha] = imread(filename);
myfilter = fspecial('gaussian',60, 5);

myfilteredimage = imfilter(I, myfilter, 'replicate');
alpha_filt = imfilter(alpha, myfilter, 'replicate');
imshow(myfilteredimage)
imwrite(myfilteredimage,filename,'Alpha',alpha_filt);
end