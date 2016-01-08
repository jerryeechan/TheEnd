[I,map,alpha] = imread('plaster4s_color1.png');
myfilter = fspecial('gaussian',60, 2);

myfilteredimage = imfilter(I, myfilter, 'replicate');
alpha_filt = imfilter(alpha, myfilter, 'replicate');
imshow(myfilteredimage)
imwrite(myfilteredimage,'plaster4s_color1_.png','Alpha',alpha_filt);
