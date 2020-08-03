package jj.sangjin.password;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.StringSelection;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class OutputPanel extends JPanel{
	private static int width = 600;
	private static int height = 500;
	
	protected int count = 0;
	protected int tcount = 0;
	protected int outputBack = 0;  // 1�̵Ǹ� ����ȭ������ ���ư��� ������ 
	private JButton backButton;
	private JButton exitButton;
	private JButton f5;
	private JTextArea password;
	private JLabel l1;
	private Font font;   // ������Ʈ ���� .
	
	
	private int[] tmp = new int[50];    //  input�� �Է��� ������ ���ڰ��� �����ϴ� �迭
	private int i = 0;   // �ݺ��� �������� ����
	private char[] element = new char[20];  // tmp�� ���ڷ� ������ ����� �� ������ ���� ���� �ƽ�Ű �ڵ�� �ؼ� ���� ���ڸ� �����ϴ� �迭
	private String Stringtemp = null;  // element�迭�� ���ո� ������ �����ϴ� ����
	private int passwordLength;   // ��й�ȣ ���̸� �󸶷� ���� ����ڰ� �Է��� ���� 
	
	private ImageIcon backButtonImage = new ImageIcon("back.png");
	private ImageIcon backButtonEnteredImage = new ImageIcon("backEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");  // ��ư�� ���� �̹��������� 
	private BufferedImage outputImage;  // �߾��ʿ� ���� �̹��� 
	
	
	public OutputPanel() {
		

		this.setLayout(null);
		
		backButton = new JButton(backButtonImage);
		exitButton = new JButton(exitButtonImage);   // ��ư�� �̹��������� �ְ� ���� 
		f5 = new JButton("F5");   // ���ΰ�ħ�� ��ư 
		password = new JTextArea(50,500);      // TextArea ���� 
		JScrollPane scroll = new JScrollPane(password);  // TextArea�� ��ũ�ѱ�� �߰� 
		
	    try {
	    	outputImage = ImageIO.read(new File("outputImage.png"));
			File outFile= new File("out.txt");
			if(!outFile.exists())outFile.createNewFile();
			Scanner s = new Scanner(new BufferedReader(new FileReader(outFile)));
			String passwordTemp;
			while(s.hasNext()) {
				passwordTemp = s.next();
				if(passwordTemp.equals("����")) {
					count++;
					continue;
				}
				
				else if(count == 1) {
					count++;
					continue;
				}
				else if(count == 2) {
					passwordLength = Integer.parseInt(passwordTemp);
					count++;	
					continue;
				}
				else if(count == 3 && passwordTemp.equals(":")) {
					count++;
				}
				else if(count == 4) {
					for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp�迭�� �ʱ�ȭ�Ѵ�  
					for(i = 0; i < 20; i++)
						element[i]  = 0;
					for(i = 0;i < passwordTemp.length(); i++) { 
						tmp[i] =(int) passwordTemp.charAt(i);  // �Է��� �� ���̱��� tmp�迭��  �򹮹����� char�� ���ڰ��� �ִ´� 
					}
					
					
					passwordMake pm = new passwordMake();   // �ؽ���ȣ������ �� �ڸ������� ��ȣ�� ����� �޼ҵ尡 �ִ� ��ä�� �����Ѵ� 
					
					element[0] =(char) pm.oneChange(tmp, passwordTemp.length());
					element[1] =(char) pm.twoChange(tmp, passwordTemp.length());
					element[2] =(char) pm.threeChange(tmp, passwordTemp.length());
					element[3] =(char) pm.fourChange(tmp, passwordTemp.length());  //4~20�ڸ����� ������ 4�ڸ��� �Ǿ �� �ڸ��� �´� �޼ҵ带 ȣ���Ѵ� 
					
					if(passwordLength >= 5) 
						element[4] =(char) pm.fiveChange(tmp, passwordTemp.length());
					if(passwordLength >= 6) 
						element[5] =(char) pm.sixChange(tmp, passwordTemp.length());
					if(passwordLength >= 7) 
						element[6] =(char) pm.sevenChange(tmp, passwordTemp.length());
					if(passwordLength >= 8) 
						element[7] =(char) pm.eightChange(tmp, passwordTemp.length());
					if(passwordLength >= 9) 
						element[8] =(char) pm.nineChange(tmp, passwordTemp.length());
					if(passwordLength >= 10) 
						element[9] =(char) pm.tenChange(tmp, passwordTemp.length());
					if(passwordLength >= 11) 
						element[10] =(char) pm.elevenChange(tmp, passwordTemp.length());
					if(passwordLength >= 12) 
						element[11] =(char) pm.twelveChange(tmp, passwordTemp.length());
					if(passwordLength >= 13) 
						element[12] =(char) pm.thirteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 14) 
						element[13] =(char) pm.fourteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 15) 
						element[14] =(char) pm.fifteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 16) 
						element[15] =(char) pm.sixteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 17)
						element[16] =(char) pm.seventeenChange(tmp, passwordTemp.length());
					if(passwordLength >= 18)
						element[17] =(char) pm.eighteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 19)
						element[18] =(char) pm.nineteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 20)
						element[19] =(char) pm.twentyChange(tmp, passwordTemp.length());  //�Է��� �ڸ������� �޼ҵ带 �����Ѵ� 

					element[0] =(char) ((char)((char)element[0] % 10) + 48);  
					element[1] =(char) ((char)((char)element[1] % 26) + 97);
					element[2] =(char) ((char)((char)element[2] % 26) + 65);
					element[3] =(char) ((char)((char)element[3] % 15) + 33); // ù 4�ڸ��� ������ ����,���ҹ���,���빮�� ,Ư�����ڰ� ���� �Ѵ� 
									
					Stringtemp = String.valueOf(element);  //char�� String���� ��ȯ���ش� 

				    count = 0;
					password.append(Stringtemp + "\n");
					passwordLength = 0;
					tcount = 0;
					continue;
					}// �� �̿��� ������ �ٽ� �����·� ������Ų�� 
				
				if(passwordTemp.equals("�н�����") && count == 0) {
					tcount++;
				}
				else if(tcount == 1) {
					tcount++;
				}
				else if(tcount == 2) {
					password.append(passwordTemp + "\n");
					tcount = 0;
					continue;
					
				}
				password.append(passwordTemp + "  ");
	    }
			s.close();   // �̹����� �߰��ϰ� ������ �ҷ��ͼ� TextArea�� �߰��Ѵ� 
		} catch (IOException e1) {
			e1.printStackTrace();
		}

		scroll.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
		scroll.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);  // ��ũ�ѿ� ��ũ�ѹ� �߰� 
		

		backButton.setBorderPainted(false);
		backButton.setContentAreaFilled(false);
		backButton.setFocusPainted(false);
		backButton.setBounds(0,0,86,80);
		exitButton.setBorderPainted(false);
		exitButton.setContentAreaFilled(false);
		exitButton.setFocusPainted(false);
		exitButton.setBounds(width-100,0,86,80);
		scroll.setBounds(132,200,325,200);
		f5.setBounds(50,250,50,50);  // ������Ʈ ��ġ 
		
		backButton.addMouseListener(new MouseAdapter(){  // ������� �ڷΰ��� ��ư�� ���� ���콺 �̺�Ʈ 
			public void mousePressed(MouseEvent e) {
					outputBack = 1;  // Ŭ���ϸ� �����гη� 
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));	
			}

			public void mouseEntered(MouseEvent e) {
				backButton.setIcon(backButtonEnteredImage);
				backButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			public void mouseExited(MouseEvent e) {
				backButton.setIcon(backButtonImage);
				backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		exitButton.addMouseListener(new MouseAdapter() {   // ������� �����ϱ� ��ư�� ���� ���콺 �̺�Ʈ ó�� 
			public void mousePressed(MouseEvent e) {  // Ŭ���� ���� 
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) {
				exitButton.setIcon(exitButtonEnteredImage);
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {
				exitButton.setIcon(exitButtonImage);
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		f5.addMouseListener(new MouseAdapter() {   // ���ΰ�ħ ��ư�� ���� ���콺 �̺�Ʈ ó�� 
			public void mousePressed(MouseEvent e) { // Ŭ���� 
				try {
					password.setText("");
			    	outputImage = ImageIO.read(new File("outputImage.png"));
					File outFile= new File("out.txt");
					if(!outFile.exists())outFile.createNewFile();
					Scanner s = new Scanner(new BufferedReader(new FileReader(outFile)));
					String passwordTemp;
					while(s.hasNext()) {
						
						passwordTemp = s.next();
						if(passwordTemp.equals("����")) {
							count++;
							continue;
						}
						
						else if(count == 1) {
							count++;
							continue;
						}
						else if(count == 2) {
							passwordLength = Integer.parseInt(passwordTemp);
							count++;	
							continue;
						}
						else if(count == 3 && passwordTemp.equals(":")) {
							count++;
						}
						else if(count == 4) {
							for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp�迭�� �ʱ�ȭ�Ѵ�  
							for(i = 0; i < 20; i++)
								element[i]  = 0;
							for(i = 0;i < passwordTemp.length(); i++) { 
								tmp[i] =(int) passwordTemp.charAt(i);  // �Է��� �� ���̱��� tmp�迭��  �򹮹����� char�� ���ڰ��� �ִ´� 
							}
							
							
							passwordMake pm = new passwordMake();   // �ؽ���ȣ������ �� �ڸ������� ��ȣ�� ����� �޼ҵ尡 �ִ� ��ä�� �����Ѵ� 
							
							element[0] =(char) pm.oneChange(tmp, passwordTemp.length());
							element[1] =(char) pm.twoChange(tmp, passwordTemp.length());
							element[2] =(char) pm.threeChange(tmp, passwordTemp.length());
							element[3] =(char) pm.fourChange(tmp, passwordTemp.length());  //4~20�ڸ����� ������ 4�ڸ��� �Ǿ �� �ڸ��� �´� �޼ҵ带 ȣ���Ѵ� 
							
							if(passwordLength >= 5) 
								element[4] =(char) pm.fiveChange(tmp, passwordTemp.length());
							if(passwordLength >= 6) 
								element[5] =(char) pm.sixChange(tmp, passwordTemp.length());
							if(passwordLength >= 7) 
								element[6] =(char) pm.sevenChange(tmp, passwordTemp.length());
							if(passwordLength >= 8) 
								element[7] =(char) pm.eightChange(tmp, passwordTemp.length());
							if(passwordLength >= 9) 
								element[8] =(char) pm.nineChange(tmp, passwordTemp.length());
							if(passwordLength >= 10) 
								element[9] =(char) pm.tenChange(tmp, passwordTemp.length());
							if(passwordLength >= 11) 
								element[10] =(char) pm.elevenChange(tmp, passwordTemp.length());
							if(passwordLength >= 12) 
								element[11] =(char) pm.twelveChange(tmp, passwordTemp.length());
							if(passwordLength >= 13) 
								element[12] =(char) pm.thirteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 14) 
								element[13] =(char) pm.fourteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 15) 
								element[14] =(char) pm.fifteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 16) 
								element[15] =(char) pm.sixteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 17)
								element[16] =(char) pm.seventeenChange(tmp, passwordTemp.length());
							if(passwordLength >= 18)
								element[17] =(char) pm.eighteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 19)
								element[18] =(char) pm.nineteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 20)
								element[19] =(char) pm.twentyChange(tmp, passwordTemp.length());  //�Է��� �ڸ������� �޼ҵ带 �����Ѵ� 

							element[0] =(char) ((char)((char)element[0] % 10) + 48);  
							element[1] =(char) ((char)((char)element[1] % 26) + 97);
							element[2] =(char) ((char)((char)element[2] % 26) + 65);
							element[3] =(char) ((char)((char)element[3] % 15) + 33); // ù 4�ڸ��� ������ ����,���ҹ���,���빮�� ,Ư�����ڰ� ���� �Ѵ� 
											
							Stringtemp = String.valueOf(element);  //char�� String���� ��ȯ���ش� 
						    count = 0;
						    tcount = 0;
							password.append(Stringtemp + "\n");
							continue;
							}// �� �̿��� ������ �ٽ� �����·� ������Ų�� 
						
						if(passwordTemp.equals("�н�����")) {
							tcount++;
						}
						else if(tcount == 1) {
							tcount++;
						}
						else if(tcount == 2) {
							password.append(passwordTemp + "\n");
							tcount = 0;
							continue;
							
						}
						password.append(passwordTemp + "  ");
					}
					s.close();
				} catch (IOException e1) {
					e1.printStackTrace();
				}
			    }
			@Override
			public void mouseEntered(MouseEvent e) {
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		this.add(exitButton);
		this.add(backButton);
		this.add(scroll);
		this.add(f5);  // ���� ������Ʈ �߰� 

		
	}
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		g.drawImage(outputImage,110, 120, 350, 70,null);  // �̹��� �߰� 
	}
		
	
}
